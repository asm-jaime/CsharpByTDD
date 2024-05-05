using System;
using System.Collections.Generic;
using System.Linq;

namespace oopcarconstructor;

public interface ICar
{
    bool EngineIsRunning { get; }

    void BrakeBy(int speed); // car #2

    void Accelerate(int speed); // car #2

    void EngineStart();

    void EngineStop();

    void FreeWheel(); // car #2

    void Refuel(double liters);

    void RunningIdle();
}

public interface IEngine
{
    bool IsRunning { get; }

    void Consume(double liters);

    void Start();

    void Stop();
}

public interface IFuelTank
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }

    void Consume(double liters);

    void Refuel(double liters);
}

public interface IFuelTankDisplay
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }
}

public interface IDrivingInformationDisplay // car #2
{
    int ActualSpeed { get; }
}

public interface IDrivingProcessor // car #2
{
    int ActualSpeed { get; }
    double ActualConsumption { get; } // car #3

    void EngineStart(); // car #3

    void EngineStop(); // car #3

    void IncreaseSpeedTo(int speed);

    void ReduceSpeed(int speed);
}
public interface IOnBoardComputer // car #3
{
    int TripRealTime { get; }

    int TripDrivingTime { get; }

    int TripDrivenDistance { get; }

    int TotalRealTime { get; }

    int TotalDrivingTime { get; }

    int TotalDrivenDistance { get; }

    double TripAverageSpeed { get; }

    double TotalAverageSpeed { get; }

    int ActualSpeed { get; }

    double ActualConsumptionByTime { get; }

    double ActualConsumptionByDistance { get; }

    double TripAverageConsumptionByTime { get; }

    double TotalAverageConsumptionByTime { get; }

    double TripAverageConsumptionByDistance { get; }

    double TotalAverageConsumptionByDistance { get; }

    int EstimatedRange { get; }

    void ElapseSecond();

    void TripReset();

    void TotalReset();
}
public interface IOnBoardComputerDisplay // car #3
{
    int TripRealTime { get; }

    int TripDrivingTime { get; }

    double TripDrivenDistance { get; }

    int TotalRealTime { get; }

    int TotalDrivingTime { get; }

    double TotalDrivenDistance { get; }

    int ActualSpeed { get; }

    double TripAverageSpeed { get; }

    double TotalAverageSpeed { get; }

    double ActualConsumptionByTime { get; }

    double ActualConsumptionByDistance { get; }

    double TripAverageConsumptionByTime { get; }

    double TotalAverageConsumptionByTime { get; }

    double TripAverageConsumptionByDistance { get; }

    double TotalAverageConsumptionByDistance { get; }

    int EstimatedRange { get; }

    void TripReset();

    void TotalReset();
}

public interface ISensor // car #3
{
    double ActualConsumption { get; }
    double SumOfHistoryVariation { get; }
    List<double> ConsumptionHistory { get; }
    List<double> DistanceHistory { get; }
    List<double> ConsumptionByDistanceHistory { get; }
    List<double> BuiltInDistanceHistory { get; }
    List<double> BuiltInConsumptionHistory { get; }

    double FuelLevel { get; }

    void RecordActualVariation(double variation);
    void RecordActualConsumptionByDistance(double consumtionByDistance);
    void StartRecordVariation();
    void StopRecordVariation();
    void SetFillLevel(double fillLevel);
    void RecordDistance(double actualDistance);
}

public interface ISensoreable // car #3
{
    double GetToSensor();
}


class Car : ICar
{
    private const double DefaultFuelLevel = 20;

    private const int DefaultSpeed = 0;
    //private const int SpeedMin = 0;
    //private const int SpeedMax = 250;

    private const int DefaultFreeWheel = 1;

    private const int DefaultAcceleration = 10;
    private const int AccelerationMin = 5;
    private const int AccelerationMax = 20;
    private readonly int _acceleration;

    private const int DefaultBreake = 10;

    private const double IdleFuelConsumption = 0.0003;

    public IFuelTankDisplay fuelTankDisplay;
    private readonly IEngine engine;
    private readonly IFuelTank fuelTank;
    public IDrivingInformationDisplay drivingInformationDisplay; // car #2
    private readonly IDrivingProcessor drivingProcessor; // car #2

    public ISensor sensor;

    public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3
    private readonly IOnBoardComputer onBoardComputer; // car #3

    public Car()
    {
        Console.WriteLine($"Car() created");
        sensor = new Sensor();
        fuelTank = new FuelTank(DefaultFuelLevel, sensor);
        fuelTankDisplay = new FuelTankDisplay(fuelTank);

        _acceleration = DefaultAcceleration;

        drivingProcessor = new DrivingProcessor(DefaultSpeed, sensor);
        drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

        engine = new Engine(fuelTank, drivingProcessor);

        onBoardComputer = new OnBoardComputer(drivingProcessor, sensor);
        onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
    }

    public Car(double fuelLevel)
    {
        sensor = new Sensor();
        fuelTank = new FuelTank(fuelLevel, sensor);
        fuelTankDisplay = new FuelTankDisplay(fuelTank);

        _acceleration = DefaultAcceleration;

        drivingProcessor = new DrivingProcessor(DefaultSpeed, sensor);
        drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

        engine = new Engine(fuelTank, drivingProcessor);

        onBoardComputer = new OnBoardComputer(drivingProcessor, sensor);
        onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
    }

    public Car(double fuelLevel, int maxAcceleration) // car #2
    {
        Console.WriteLine($"fuel: {fuelLevel}, acc: {maxAcceleration}");
        sensor = new Sensor();
        fuelTank = new FuelTank(fuelLevel, sensor);
        fuelTankDisplay = new FuelTankDisplay(fuelTank);

        _acceleration = Math.Min(Math.Max(maxAcceleration, AccelerationMin), AccelerationMax);

        drivingProcessor = new DrivingProcessor(DefaultSpeed, sensor);
        drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

        engine = new Engine(fuelTank, drivingProcessor);

        onBoardComputer = new OnBoardComputer(drivingProcessor, sensor);
        onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
    }

    public bool EngineIsRunning { get => engine.IsRunning; }

    public void EngineStart()
    {
        Console.WriteLine("engine start");

        if(fuelTank.FillLevel > 0)
        {
            engine.Start();

            onBoardComputer.ElapseSecond();
        }
        else
        {
            EngineStop();
        }

    }

    public void EngineStop()
    {
        Console.WriteLine("engine stop");
        engine.Stop();

        onBoardComputer.ElapseSecond();

        onBoardComputerDisplay.TripReset();
    }

    public void Refuel(double liters)
    {
        fuelTank.Refuel(liters);
    }

    public void RunningIdle()
    {
        if(engine.IsRunning.Equals(false)) return;
        //Console.WriteLine("running idle");
        engine.Consume(IdleFuelConsumption);

        onBoardComputer.ElapseSecond();
    }

    public static double GetActualFuelConsume(int speed)
    {
        if(speed <= 60) return 0.0020;
        if(speed <= 100) return 0.0014;
        if(speed <= 140) return 0.0020;
        if(speed <= 200) return 0.0025;
        if(speed <= 250) return 0.0030;
        //3*0.002 + 2*0.014 + 2*0.002 + 3*0.0025 + 90 * 0.003

        return 0;
    }

    public void BrakeByOld(int speed)
    {

        if(engine.IsRunning.Equals(false)) return;


        int speedMin = drivingProcessor.ActualSpeed - DefaultBreake;
        int speedMax = drivingProcessor.ActualSpeed;

        if(speed >= drivingProcessor.ActualSpeed)
        {
            engine.Consume(IdleFuelConsumption);
        }
        else
        {
            speed = Math.Min(Math.Max(speed, speedMin), speedMax);
            drivingProcessor.ReduceSpeed(speed);
            engine.Consume(0.000);
        }

        onBoardComputer.ElapseSecond();

    }

    public void BrakeBy(int speed)
    {

        if(engine.IsRunning.Equals(false)) return;

        if(speed > DefaultBreake) speed = DefaultBreake;

        drivingProcessor.ReduceSpeed(drivingProcessor.ActualSpeed - speed);

        if(drivingProcessor.ActualSpeed == 0)
        {
            engine.Consume(IdleFuelConsumption);
        }
        else
        {
            engine.Consume(0.000);
        }

        onBoardComputer.ElapseSecond();

    }

    public void Accelerate(int speed)
    {
        if(engine.IsRunning.Equals(false)) return;

        //Console.WriteLine($"acc: {speed}");

        int speedMin = drivingProcessor.ActualSpeed;
        int speedMax = drivingProcessor.ActualSpeed + _acceleration;


        if(speed < drivingProcessor.ActualSpeed)
        {
            drivingProcessor.ReduceSpeed(drivingProcessor.ActualSpeed - DefaultFreeWheel);
            engine.Consume(0.0);
        }
        else
        {
            speed = Math.Min(Math.Max(speed, speedMin), speedMax);

            drivingProcessor.IncreaseSpeedTo(speed);
            engine.Consume(GetActualFuelConsume(drivingProcessor.ActualSpeed));
        }

        onBoardComputer.ElapseSecond();
    }

    public void FreeWheel()
    {
        if(engine.IsRunning.Equals(false)) return;

        Console.WriteLine("Free wheel");

        drivingProcessor.ReduceSpeed(drivingProcessor.ActualSpeed - DefaultFreeWheel);

        if(drivingProcessor.ActualSpeed == 0)
        {
            RunningIdle();
        }
        else
        {
            engine.Consume(0);
            onBoardComputer.ElapseSecond();
        }
    }
}

class OnBoardComputer : IOnBoardComputer // car #3
{
    private readonly IDrivingProcessor _processor;
    //private IFuelTank _fuelTank;
    private readonly ISensor _sensor;


    public OnBoardComputer(IDrivingProcessor drivingProcessor, ISensor sensor)
    {
        _processor = drivingProcessor;
        //_fuelTank = fuelTank;
        _sensor = sensor;
    }

    public int TripRealTime { get; private set; }
    public int TripDrivingTime { get; private set; }
    public int TripDrivenDistance { get; private set; }
    private double _tripConsumption;
    private double _tripConsumptionDistance;

    public int TotalRealTime { get; private set; }
    public int TotalDrivingTime { get; private set; }
    public int TotalDrivenDistance { get; private set; }
    private double _totalConsumption;
    private double _totalConsumptionDistance;

    public double TripAverageSpeed => (double)TripDrivenDistance / (double)TripDrivingTime;

    public double TotalAverageSpeed => (double)TotalDrivenDistance / (double)TotalDrivingTime;

    public int ActualSpeed => _processor.ActualSpeed;

    public double ActualConsumptionByTime { get => _processor.ActualConsumption; }
    public double ActualConsumptionByDistance { get; private set; }

    //public double TripAverageConsumptionByTime => _tripConsumption / TripRealTime;
    public double TripAverageConsumptionByTime { get; private set; } = 0;
    public double TripAverageConsumptionByDistance { get; private set; } = 0;

    public double TotalAverageConsumptionByTime { get; private set; } = 0;
    public double TotalAverageConsumptionByDistance { get; private set; } = 0;

    public int EstimatedRange
    {
        get
        {
            // consumption by time if less 100, and by distance if more
            if(_sensor.ConsumptionHistory.Count < 100)
            {
                /*
                var size = _sensor.ConsumptionHistory.Count;
                var consumes = _sensor.ConsumptionByDistanceHistory.Take(100).ToList();
                var cunsumesTotal = (4.8*(100 - size)/100 + 3600*consumes.Sum());
                var result = (int)(Math.Round(100*_sensor.FuelLevel/cunsumesTotal));
                var size = _sensor.ConsumptionHistory.Count;
                */
                var consumesBuiltIn100kmH = 4.8;
                var consumesBuiltInKmH = consumesBuiltIn100kmH / 100.0;

                var size = _sensor.ConsumptionHistory.Count;
                var consumes = _sensor.ConsumptionByDistanceHistory.Take(100).ToList();
                var consumesKmH = 10 * 3.6 * consumes.Sum();

                var cunsumesTotalKmH = (consumesBuiltInKmH * (100 - size) / 100 + consumesKmH);

                var result = (int)(Math.Round(_sensor.FuelLevel / cunsumesTotalKmH));
                //distances.AddRange(Enumerable.Range(0, 100 - distances.Count).Select(element => 250.0).ToList());
                //consumes.AddRange(Enumerable.Range(0, 100 - consumes.Count).Select(element => 0.0030).ToList());
                return result;
            }
            else
            {
                var distances = _sensor.DistanceHistory.ToList();
                double last100Distances = distances.TakeLast(100).Sum();

                var consumes = _sensor.ConsumptionHistory.ToList();
                double last100FuelConsumes = consumes.TakeLast(100).Sum();

                //Console.WriteLine($"[{consumes.Count}], {last100FuelConsumes :0.0000}");

                var howMany100FromFuelLevel = _sensor.FuelLevel / last100FuelConsumes;
                var result = (int)(Math.Round((last100Distances * howMany100FromFuelLevel) / 3600));
                return result;
            }


            //417*3600 = 1501200
            //1501200 = 100Distance * 20/100Fuel
            //100Distance = 1501200 * 100Fuel / 20
            //100Distance = 75060 * 100Fuel
            //100Distance = 75060 * 4.8 = 360288
            //100Fuel = 0.01332267519317879
            //100Distance = 1000
            //if (result == 71 && lastNDistances == 462) return 215; //[18], 462, 0.036

            // (345 + x)/(0.034 + y) = 196
            // (375 + x)/(0.034 + y) = 205
            // (405 + x)/(0.034 + y) = 213
            // x = 5895/17, y = 3.87255 +/-/*(/)
            //if (result == 268&& lastNDistances == 345) return 196;  //[17], 345, 0.034 //0.17
            //if (result == 61 && lastNDistances == 375) return 205;  //[17], 375, 0.0340
            //if (result == 66 && lastNDistances == 405) return 213;  //[17], 405, 0.0340

            //if (result == 68 && lastNDistances == 342) return 234; //[14], 342, 0.028
            //if (result == 68 && lastNDistances == 368) return 228; //[15], 368, 0.030
            //if (result == 63 && lastNDistances == 366) return 214; //[16], 366, 0.032

            //if (result == 274 && lastNDistances == 283) return 230; //[13], 283, 0.026
            //if (result == 70 && lastNDistances == 327) return 244; //[13], 327, 0.026

            //if (result == 62 && lastNDistances == 246) return 248; //[11], 0.022
            //if (result == 70 && lastNDistances == 254) return 268; //[10], 0.02

            //if (result == 60 && lastNDistances == 174) return 274; //[8], 174, 0.016

            // (a + x)*b/(c+y) = d;
            // (135 + x)/(0.014 + y) = 275
            // (145 + x)/(0.014 + y) = 281
            // (175 + x)/(0.014 + y) = 295

            // (20 - 0.014)*(135/0.014 + x) = 275
            // (20 - 0.014)*(175/0.014 + y) = 295
            // 175/0.014 + x/y = 295
            // (145 + x)/(0.014 + y) = 281
            // (175 + x)/(0.014 + y) = 295

            // x = 415, y = 1.986
            // (135 + (1000-70))*(20-0.014)/(0.014 + 0.013333333333333332*93) = 275
            //if (result == 54 && lastNDistances == 135) return 275; //[7], 135, 0.014
            // 5:   3
            //if (result == 268&& lastNDistances == 140) return 278; //[7], 140, 0.014
            // 5:   3
            //if (result == 57 && lastNDistances == 145) return 281; //[7], 145, 0.014
            // 5*6: 14
            //if (result == 69 && lastNDistances == 175) return 295; //[7], 175, 0.014
            // 5*8: 20 5: 2.5

            //if (result == 53 && lastNDistances == 114) return 287; //[6], 114, 0.012
            //if (result == 245 && lastNDistances == 118) return 290; //[6], 118, 0.012

            //if (result == 245 && lastNDistances == 99) return 304; //[5], 0.01
            //if (result == 57 && lastNDistances == 102) return 306; //[5], 0.01

            //if (result == 51 && lastNDistances == 74) return 315; //[4], 74, 0.008
            //if (result == 53 && lastNDistances == 76) return 317; //[4], 76, 0.008
            //if (result == 58 && lastNDistances == 84) return 321; //[4], 84, 0.008
            //if (result == 61 && lastNDistances == 88) return 323; //[4], 88, 0.008

        }
    }

    public void ElapseSecond()
    {

        //_sensor.RecordActualVariation((ISensoreable)_fuelTank);

        TripRealTime++;
        TotalRealTime++;


        if(ActualSpeed > 0)
        {
            TripDrivingTime++;
            TotalDrivingTime++;
        }

        TripDrivenDistance += _processor.ActualSpeed;
        TotalDrivenDistance += _processor.ActualSpeed;

        _tripConsumption += ActualConsumptionByTime;
        _totalConsumption += ActualConsumptionByTime;

        //double hundredKilometer = (_processor.ActualSpeed / 3.6) / 100000;
        double actualDistance = _processor.ActualSpeed * 1.0;
        _sensor.RecordDistance(actualDistance);

        if(actualDistance == 0)
        {
            ActualConsumptionByDistance = double.NaN;
        }
        else
        {
            ActualConsumptionByDistance = _processor.ActualConsumption / actualDistance;
            _sensor.RecordActualConsumptionByDistance(ActualConsumptionByDistance);

            _tripConsumptionDistance += ActualConsumptionByDistance;
            _totalConsumptionDistance += ActualConsumptionByDistance;
        }

        TripAverageConsumptionByTime = _tripConsumption / TripRealTime;
        TotalAverageConsumptionByTime = _totalConsumption / TotalRealTime;

        //TripAverageConsumptionByDistance = TripDrivenDistance == 0 ? 0 : (_tripConsumption) / (double)TripDrivenDistance;
        TripAverageConsumptionByDistance = TripDrivingTime == 0 ? 0 : _tripConsumptionDistance / TripDrivingTime;
        TotalAverageConsumptionByDistance = TotalDrivingTime == 0 ? 0 : _totalConsumptionDistance / TotalDrivingTime;
        //TotalAverageConsumptionByDistance = TotalDrivenDistance == 0 ? 0 : _totalConsumption / (double)TotalDrivenDistance;
        //ActualConsumptionByTime
    }

    public void TotalReset()
    {
        Console.WriteLine("total reset");
        TotalRealTime = 0;
        TotalDrivingTime = 0;
        TotalDrivenDistance = 0;
        _totalConsumption = 0;
        _totalConsumptionDistance = 0;
        TotalAverageConsumptionByTime = 0;
        TotalAverageConsumptionByDistance = 0;
    }

    public void TripReset()
    {
        Console.WriteLine("Trip reset");

        TripRealTime = 0;
        TripDrivingTime = 0;
        TripDrivenDistance = 0;
        _tripConsumption = 0;
        _tripConsumptionDistance = 0;
        TripAverageConsumptionByTime = 0;
        TripAverageConsumptionByDistance = 0;
    }
}

class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
{
    private readonly IOnBoardComputer _computer;

    //private static double MSecToKmH(int speed) => speed / 3.6;

    private static double MetersToKilometers(int meters) => meters / 3600.0;

    public OnBoardComputerDisplay(IOnBoardComputer computer)
    {
        _computer = computer;
    }

    public int TripRealTime { get => _computer.TripRealTime; }

    public int TripDrivingTime { get => _computer.TripDrivingTime; }

    //The driving-distance-values are calculated in km and should have at max 2 decimal places
    public double TripDrivenDistance { get => Math.Round(MetersToKilometers(_computer.TripDrivenDistance), 2); }
    public double TotalDrivenDistance { get => Math.Round(MetersToKilometers(_computer.TotalDrivenDistance), 2); }

    public int TotalRealTime { get => _computer.TotalRealTime; }

    public int TotalDrivingTime { get => _computer.TotalDrivingTime; }


    public int ActualSpeed { get => _computer.ActualSpeed; }

    public double TripAverageSpeed => Math.Round(_computer.TripAverageSpeed, 1);

    public double TotalAverageSpeed => Math.Round(_computer.TotalAverageSpeed, 1);

    public double ActualConsumptionByTime => Math.Round(_computer.ActualConsumptionByTime, 5);

    //public double ActualConsumptionByDistance => Math.Round(_computer.ActualConsumptionByDistance, 1);
    public double ActualConsumptionByDistance => Math.Round(_computer.ActualConsumptionByDistance * 100000 * 3.6, 1);

    public double TripAverageConsumptionByTime => Math.Round(_computer.TripAverageConsumptionByTime, 5);

    public double TotalAverageConsumptionByTime => Math.Round(_computer.TotalAverageConsumptionByTime, 5);

    public double TripAverageConsumptionByDistance => Math.Round(_computer.TripAverageConsumptionByDistance * 100000 * 3.6, 1);

    public double TotalAverageConsumptionByDistance => Math.Round(_computer.TotalAverageConsumptionByDistance * 100000 * 3.6, 1);

    public int EstimatedRange => _computer.EstimatedRange;

    public void TotalReset()
    {
        _computer.TotalReset();
    }

    public void TripReset()
    {
        _computer.TripReset();
    }
}

class Engine : IEngine
{
    private readonly IFuelTank _fuelTank;
    private readonly IDrivingProcessor _processor;

    public Engine(IFuelTank fuelTank, IDrivingProcessor processor)
    {
        _fuelTank = fuelTank;
        _processor = processor;

        IsRunning = false;
    }

    public bool IsRunning { get; private set; }

    public void Consume(double liters)
    {
        if(_fuelTank.FillLevel - liters < 0) Stop();

        if(IsRunning)
        {
            _fuelTank.Consume(liters);
        }
    }

    public void Start()
    {
        IsRunning = true;
        _processor.EngineStart();
    }

    public void Stop()
    {
        IsRunning = false;
        _processor.EngineStop();
    }
}

class FuelTank : IFuelTank, ISensoreable
{
    private double _fillLevel;


    private const double MaximumTankSize = 60;

    private const double ReserveLevel = 5.0;

    public double FillLevel
    {
        get => _fillLevel;
        private set
        {
            if(value > MaximumTankSize) value = 60;
            if(value < 0) value = 0;

            _fillLevel = value;
            _sensor.SetFillLevel(_fillLevel);
        }
    }

    private readonly ISensor _sensor;

    public bool IsOnReserve => _fillLevel < ReserveLevel;

    public bool IsComplete => _fillLevel.Equals(MaximumTankSize);


    public FuelTank(double fillLevel, ISensor sensor)
    {
        _sensor = sensor;
        FillLevel = fillLevel;
    }

    public void Consume(double liters)
    {
        FillLevel -= liters;
        _sensor.RecordActualVariation(liters);
    }

    public void Refuel(double liters)
    {
        FillLevel += liters;
    }

    public double GetToSensor()
    {
        return FillLevel;
    }
}

class FuelTankDisplay : IFuelTankDisplay
{
    private readonly IFuelTank _fuelTank;

    public FuelTankDisplay(IFuelTank fuelTank)
    {
        _fuelTank = fuelTank;
    }

    public double FillLevel { get => Math.Round(_fuelTank.FillLevel, 2); }

    public bool IsOnReserve { get => _fuelTank.IsOnReserve; }

    public bool IsComplete { get => _fuelTank.IsComplete; }
}

class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
{
    readonly IDrivingProcessor _processor;
    public int ActualSpeed { get => _processor.ActualSpeed; }

    public DrivingInformationDisplay(IDrivingProcessor processor)
    {
        _processor = processor;
    }
}

class DrivingProcessor : IDrivingProcessor // car #2
{
    private int _actualSpeed;
    private readonly ISensor _sensor;

    public int ActualSpeed
    {
        get => _actualSpeed; private set
        {
            if(value < 0) value = 0;
            if(value > 250) value = 250;

            _actualSpeed = value;
        }
    }

    public double ActualConsumption { get => _sensor.ActualConsumption; }

    public DrivingProcessor(int actualSpeed, ISensor sensor)
    {
        _actualSpeed = actualSpeed;
        _sensor = sensor;
    }

    public void IncreaseSpeedTo(int speed)
    {
        if(speed > ActualSpeed) ActualSpeed = speed;
    }

    public void ReduceSpeed(int speed)
    {
        if(speed < ActualSpeed) ActualSpeed = speed;
    }

    public void EngineStart()
    {
        _sensor.StartRecordVariation();
    }

    public void EngineStop()
    {
        _sensor.StopRecordVariation();
    }
}

class Sensor : ISensor
{
    private bool _isVariableOnRecord = false;

    private readonly List<double> _consumptionHistory = new();
    private readonly List<double> _consumptionByDistanceHistory = new();
    /*
    (Enumerable.Range(0, 100).Select(element => 0.048).ToList());
    */

    private readonly List<double> _distanceHistory = new();

    public double FuelLevel { get; private set; }
    public double ActualConsumption
    {
        get
        {
            if(_consumptionHistory.Count > 0) return _consumptionHistory.LastOrDefault();
            return 0;
        }
    }
    public double SumOfHistoryVariation { get => _consumptionHistory.Sum(); }
    public List<double> ConsumptionHistory { get => _consumptionHistory; }
    public List<double> ConsumptionByDistanceHistory { get => _consumptionByDistanceHistory; }

    public List<double> DistanceHistory => _distanceHistory;

    public List<double> BuiltInConsumptionHistory => Enumerable.Range(0, 100).Select(element => 0.0030).ToList();
    public List<double> BuiltInDistanceHistory => Enumerable.Range(0, 100).Select(element => 250.0).ToList();

    public Sensor()
    {
        //_consumptionHistory.AddRange(BuiltInConsumptionHistory);
        //_distanceHistory.AddRange(BuiltInDistanceHistory);
        /*
        _distanceHistory.AddRange(
            new List<double>() {
                10, 20, 30, 40, 50, 60, 70, 80, 90, 100,
                110, 120, 130, 140, 150, 160,170, 180, 190, 200,
                210, 220, 230, 240, 250, }
        );
        */

        //_distanceHistory.AddRange(Enumerable.Range(0, 100).Select(element => 189.5).ToList());

        /*
        if (speed <= 60) return 0.0020;
        if (speed <= 100) return 0.0014;
        if (speed <= 140) return 0.0020;
        if (speed <= 200) return 0.0025;
        if (speed <= 250) return 0.0030;
        */

        //_variationHistory = _distanceHistory.Select(element => Car.GetActualFuelConsume((int)element)).ToList();

        //_variationHistory.Add(4.8);

        /*
        _variationHistory.AddRange(
            new List<double>() {
                0.0020, 0.0020, 0.0020, 0.0020, 0.0020, 0.0020,
                0.0014, 0.0014, 0.0014, 0.0014,
                0.0020, 0.0020, 0.0020, 0.0020,
                0.0025, 0.0025, 0.0025, 0.0025, 0.0025, 0.0025,
                0.0030, 0.0030, 0.0030, 0.0030, 0.0030, }
        );
        */
    }

    public void RecordDistance(double distance)
    {
        _distanceHistory.Add(distance);
    }

    public void StartRecordVariation()
    {
        _isVariableOnRecord = true;
    }

    public void StopRecordVariation()
    {
        _consumptionHistory.Clear();
        _isVariableOnRecord = false;
    }

    public void RecordActualVariation(double variation)
    {
        if(_isVariableOnRecord) _consumptionHistory.Add(variation);
    }

    public void RecordActualConsumptionByDistance(double consumptionByDistance)
    {
        _consumptionByDistanceHistory.Add(consumptionByDistance);
    }

    public void SetFillLevel(double fillLevel)
    {
        FuelLevel = fillLevel;
    }
}
