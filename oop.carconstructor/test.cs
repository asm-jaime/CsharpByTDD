using NUnit.Framework;
using System.Linq;

namespace oopcarconstructor;

[TestFixture]
class Car1ExampleTests
{
    [Test]
    public void TestMotorStartAndStop()
    {
        var car = new Car();

        Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

        car.EngineStart();

        Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");

        car.EngineStop();

        Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
    }

    [Test]
    public void TestFuelConsumptionOnIdle()
    {
        var car = new Car(1);

        car.EngineStart();

        Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

        Assert.AreEqual(0.10, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
    }

    [Test]
    public void TestFuelTankDisplayIsComplete()
    {
        var car = new Car(60);

        Assert.IsTrue(car.fuelTankDisplay.IsComplete, "Fuel tank must be complete!");
    }

    [Test]
    public void TestFuelTankDisplayIsOnReserve()
    {
        var car = new Car(4);

        Assert.IsTrue(car.fuelTankDisplay.IsOnReserve, "Fuel tank must be on reserve!");
    }

    [Test]
    public void TestRefuel()
    {
        var car = new Car(5);

        car.Refuel(40);

        Assert.AreEqual(45, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
    }

}

[TestFixture]
class Car2ExampleTests
{
    [Test]
    public void TestStartSpeed()
    {
        var car = new Car();

        car.EngineStart();

        Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestFreeWheelSpeed()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

        Assert.AreEqual(100, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

        car.FreeWheel();
        car.FreeWheel();
        car.FreeWheel();

        Assert.AreEqual(97, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestAccelerateBy10()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

        car.Accelerate(160);
        Assert.AreEqual(110, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        car.Accelerate(160);
        Assert.AreEqual(120, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        car.Accelerate(160);
        Assert.AreEqual(130, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        car.Accelerate(160);
        Assert.AreEqual(140, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        car.Accelerate(145);
        Assert.AreEqual(145, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestBraking()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

        car.BrakeBy(20);

        Assert.AreEqual(90, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

        car.BrakeBy(10);

        Assert.AreEqual(80, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestConsumptionSpeedUpTo30()
    {
        var car = new Car(1, 20);

        car.EngineStart();

        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);

        Assert.AreEqual(0.98, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
    }

    [Test]
    public void TestMaxSpeed()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 26).ToList().ForEach(s => car.Accelerate(260));

        Assert.AreEqual(250, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void Test99Speed()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));
        car.Accelerate(30);

        Assert.AreEqual(99, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void Test255RandomSpeed()
    {
        var car = new Car(20, 6);

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(250));
        car.BrakeBy(50);
        Enumerable.Range(0, 11).ToList().ForEach(s => car.FreeWheel());
        car.Accelerate(55);

        Assert.AreEqual(19.98, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        Assert.AreEqual(45, car.drivingInformationDisplay.ActualSpeed, "Wrong speed level!");
    }
}

[TestFixture]
class Car3ExampleTests
{
    [Test]
    public void TestRealAndDrivingTimeBeforeStarting()
    {
        var car = new Car();

        Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
        Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
        Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
        Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
    }

    [Test]
    public void TestRealAndDrivingTimeAfterDriving()
    {
        var car = new Car();

        car.EngineStart();

        car.RunningIdle();
        car.RunningIdle();

        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);

        car.BrakeBy(10);
        car.BrakeBy(10);

        car.Accelerate(30);

        Assert.AreEqual(11, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
        Assert.AreEqual(8, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
        Assert.AreEqual(11, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
        Assert.AreEqual(8, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
    }

    [Test]
    public void TestActualSpeedBeforeDriving()
    {
        var car = new Car();

        car.EngineStart();

        car.RunningIdle();
        car.RunningIdle();

        Assert.AreEqual(0, car.onBoardComputerDisplay.ActualSpeed, "Wrong actual speed.");
    }

    [Test]
    public void TestAverageSpeed1()
    {
        var car = new Car();

        car.EngineStart();

        car.RunningIdle();
        car.RunningIdle();

        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);

        car.BrakeBy(10);
        car.BrakeBy(10);
        car.BrakeBy(10);

        Assert.AreEqual(18, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
        Assert.AreEqual(18, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
    }

    [Test]
    public void TestAverageSpeed2()
    {
        var car = new Car();

        car.EngineStart();

        car.Accelerate(28); // 10
        car.Accelerate(28); // 20
        car.Accelerate(28); // 28
        car.Accelerate(28); // 28
        car.Accelerate(28); // 28
        car.Accelerate(28); // 28

        Assert.AreEqual(23.7, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
        Assert.AreEqual(23.7, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
    }

    [Test]
    public void TestAverageSpeedAfterTripReset()
    {
        var car = new Car();

        car.EngineStart();

        car.RunningIdle();
        car.RunningIdle();

        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);

        car.BrakeBy(10);
        car.BrakeBy(10);
        car.BrakeBy(10);

        car.onBoardComputerDisplay.TripReset();

        car.Accelerate(20);

        car.Accelerate(20);

        Assert.AreEqual(15, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
        Assert.AreEqual(20, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
    }

    [Test]
    public void TestActualConsumptionEngineStart()
    {
        var car = new Car();

        car.EngineStart();

        Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
        Assert.AreEqual(double.NaN, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
    }

    [Test]
    public void TestActualConsumptionRunningIdle()
    {
        var car = new Car();

        car.EngineStart();

        car.RunningIdle();

        Assert.AreEqual(0.0003, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
        Assert.AreEqual(double.NaN, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
    }

    [Test]
    public void TestActualConsumptionAccelerateTo100()
    {
        var car = new Car(40, 20);

        car.EngineStart();

        car.Accelerate(100);
        car.Accelerate(100);
        car.Accelerate(100);
        car.Accelerate(100);
        car.Accelerate(100);

        // 0.002+0.002+0.002+0.0014+0.0014
        Assert.AreEqual(0.0014, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
        Assert.AreEqual(5, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
    }

    [Test]
    public void TestActualConsumptionFreeWheel()
    {
        var car = new Car(40, 20);

        car.EngineStart();

        car.Accelerate(100);
        car.Accelerate(100);
        car.Accelerate(100);
        car.Accelerate(100);
        car.Accelerate(100);

        car.FreeWheel();

        Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
        Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
    }

    [Test]
    public void TestAverageConsumptionsAfterEngineStart()
    {
        var car = new Car();

        car.EngineStart();

        Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
        Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
        Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
        Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
    }

    [Test]
    public void TestAverageConsumptionsAfterAccelerating()
    {
        var car = new Car();

        car.EngineStart();  // 0  0
        car.Accelerate(30); // 10 0.002 0.002/10
        car.Accelerate(30); // 20 0.002 0.002/20
        car.Accelerate(30); // 30 0.002 0.002/30
                            // 0.0015

        Assert.AreEqual(0.0015, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
        Assert.AreEqual(0.0015, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
        Assert.AreEqual(44, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
        Assert.AreEqual(44, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
    }

    [Test]
    public void TestAverageConsumptionsAfterBraking()
    {
        var car = new Car();

        car.EngineStart();  // 1 0.0   0
        car.Accelerate(30); // 2 0.2   10
        car.Accelerate(30); // 3 0.2   20
        car.Accelerate(30); // 4 0.2   30
        car.BrakeBy(10);    // 5 0.0   20
        car.BrakeBy(10);    // 6 0.0   10
        car.BrakeBy(10);    // 7 0.003 10
                            // 0.0009*7 = 0.0063 

        Assert.AreEqual(0.0009, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
        Assert.AreEqual(0.0009, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
        Assert.AreEqual(26.4, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
        Assert.AreEqual(26.4, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
    }

    [Test]
    public void TestDrivenDistancesAfterEngineStart()
    {
        var car = new Car();

        car.EngineStart();

        Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
        Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
    }

    [Test]
    public void TestDrivenDistancesAfterAccelerating()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 30).ToList().ForEach(c => car.Accelerate(30));

        Assert.AreEqual(0.24, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
        Assert.AreEqual(0.24, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
    }

    [Test]
    public void TestEstimatedRangeAfterDrivingOptimumSpeedForMoreThan100Seconds()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 150).ToList().ForEach(c => car.Accelerate(100));

        Assert.AreEqual(393, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
    }

    [Test]
    public void TestEstimatedRangeBeforeDriving()
    {
        var car = new Car();
        car.EngineStart();

        Assert.AreEqual(417, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
    }

    [Test]
    public void TestSome()
    {
        var car = new Car(20, 20);

        car.EngineStart();

        Enumerable.Range(0, 120).ToList().ForEach(c => car.Accelerate(250));
        var comsumptionTime = car.onBoardComputerDisplay.TotalAverageConsumptionByTime;
        var comsumptionDistance = car.onBoardComputerDisplay.TotalAverageConsumptionByDistance;
        //Assert.AreEqual(1, comsumptionTime, "Wrong Consumption distance");
        Assert.AreEqual(4.8, comsumptionDistance, "Wrong Consumption distance");
        // 0.0020*6+0.0014+44 = 0.0736
        // 550 + 40*100 = 40650
        //Assert.AreEqual(310, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
    }

    [Test]
    public void Car3RandomTests()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 9).ToList().ForEach(c => car.Accelerate(26)); // 0.0020*9 = 0.018
        /*
        Enumerable.Range(0, 91).ToList().ForEach(c => car.Accelerate(250)); // 0.0020*9 = 0.018
        var comsumptionTime = car.onBoardComputerDisplay.TotalAverageConsumptionByTime;
        var comsumptionDistance = car.onBoardComputerDisplay.TotalAverageConsumptionByDistance;
        */

        Assert.AreEqual(271, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
    }

    [Test]
    public void TestEstimatedRangeAfterDrivingSlowSpeedForLowerThan100Seconds()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 50).ToList().ForEach(c => car.Accelerate(30));
        // 0.0020*50 = 0.10
        // 60 + 47*30 = 1470
        Assert.AreEqual(133, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
    }

    [Test]
    public void TestEstimatedRangeAfterDrivingOptimumSpeedForLowerThan100Seconds()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 50).ToList().ForEach(c => car.Accelerate(100));
        var comsumption = car.onBoardComputerDisplay.TotalAverageConsumptionByTime;
        // 0.0020*6+0.0014+44 = 0.0736
        // 550 + 40*100 = 40650
        Assert.AreEqual(310, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
    }
}
