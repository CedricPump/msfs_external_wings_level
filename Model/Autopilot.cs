using System;
using System.Diagnostics;

public  sealed class Autopilot
{
    // PID gains for bank ➜ aileron
    public double BankKp { get; set; }
    public double BankKi { get; set; }
    public double BankKd { get; set; }

    // PID gains for vertical speed ➜ elevator
    public double VSKp { get; set; }
    public double VSKi { get; set; }
    public double VSKd { get; set; }

    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
    private double _lastTimeSeconds;

    // PID state for bank
    private double _bankIntegral = 0;
    private double _bankLastError = 0;

    // PID state for vertical speed
    private double _vsIntegral = 0;
    private double _vsLastError = 0;

    private double _targetBank = 0;
    private double _targetVS = 0;

    public double TargetBank 
    { 
        get { return _targetBank; }
        set 
        {
            if(_targetBank == value) return;
            // reset learned data
            _bankLastError = 0;
            _bankIntegral = 0;
            this._targetBank = value;
        }
    }
    public double TargetVS 
    {
        get { return _targetVS; }
        set
        {
            if(_targetVS == value) return;
            // reset learned data
            _vsLastError = 0;
            _vsIntegral = 0;
            this._targetVS = value;
        }
    }


    public Autopilot(
        double bankKp = 0.095, double bankKi = 0.0, double bankKd = 0.009,
        double vsKp = 0.00011, double vsKi = 0.0, double vsKd = 0.00027
    )
    {
        BankKp = bankKp;
        BankKi = bankKi;
        BankKd = bankKd;

        VSKp = vsKp;
        VSKi = vsKi;
        VSKd = vsKd;

        _lastTimeSeconds = _stopwatch.Elapsed.TotalSeconds;
    }

    /// <summary>
    /// Returns (elevator, aileron) control inputs based on current aircraft state.
    /// </summary>
    public (double elevator, double aileron) CalculateRequiredInput(double currentBankDeg, double currentVerticalSpeed)
    {
        double currentTime = _stopwatch.Elapsed.TotalSeconds;
        double dt = currentTime - _lastTimeSeconds;
        _lastTimeSeconds = currentTime;

        if (dt <= 0) dt = 0.0001;

        // --- Bank ➜ Aileron ---
        double bankError = _targetBank - currentBankDeg;

        _bankIntegral += bankError * dt;
        double bankDerivative = (bankError - _bankLastError) / dt;
        _bankLastError = bankError;

        double aileron = (BankKp * bankError) + (BankKi * _bankIntegral) + (BankKd * bankDerivative);
        aileron = Clamp(aileron, -1.0, 1.0);

        // --- VS ➜ Elevator ---
        double vsError = _targetVS - currentVerticalSpeed;

        _vsIntegral += vsError * dt;
        double vsDerivative = (vsError - _vsLastError) / dt;
        _vsLastError = vsError;

        double elevator = (VSKp * vsError) + (VSKi * _vsIntegral) + (VSKd * vsDerivative);
        elevator = Clamp(elevator, -1.0, 1.0);

        // Invert aileron if needed (MSFS often has left positive)
        return (elevator, -aileron);
    }

    private static double Clamp(double value, double min, double max)
    {
        return Math.Max(min, Math.Min(max, value));
    }
}
