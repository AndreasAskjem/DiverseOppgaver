using System;

namespace Vann
{
    public class Water
    {
        public double Temperature { get; set; }
        public double Amount { get; set; }
        public WaterState State { get; set; }
        public double? ProportionFirstState { get; set; }

        private static int _energyFromIceToLiquid = 80;
        private static int _energyFromLiquidToGas = 600;

        public Water(int amount, int temperature, double? proportion=null)
        {
            if ((temperature == 0 || temperature == 100) && proportion == null)
            {
                throw new ArgumentException("When temperature is 0 or 100, you must provide a value for proportion");
            }

            Temperature = temperature;
            Amount = amount;
            ProportionFirstState = proportion;

            SetState();

            if (State == WaterState.Ice && proportion != null)
            {
                State = WaterState.IceAndFluid;
            }

            if (State == WaterState.Fluid && proportion != null)
            {
                State = WaterState.FluidAndGas;
            }
        }

        private void SetState()
        {

            State = Temperature < 0 ? WaterState.Ice : Temperature <= 100 ? WaterState.Fluid : WaterState.Gas;

            /*
            if (Temperature < 0)
            {
                State = "solid";
            }
            else if (Temperature <= 100)
            {
                State = "liquid";
            }
            else
            {
                State = "gas";
            }
            */
        }

        public enum WaterState
        {
            Fluid, Ice, Gas, FluidAndGas, IceAndFluid
        }

        public void AddEnergy(double calories)
        {
            var increaseInTemperature = calories / Amount;

            if (Temperature <= 0 &&
                Temperature + increaseInTemperature >= 0 && 
                (State == WaterState.Ice || State == WaterState.IceAndFluid))
            {
                calories += Amount * Temperature;
                Temperature = 0;

                var amountMelted = calories / _energyFromIceToLiquid;
                if (amountMelted >= Amount)
                {
                    State = WaterState.Fluid;
                    calories -= Amount * _energyFromIceToLiquid;
                }
                else
                {
                    ProportionFirstState = 1 - amountMelted/Amount;
                    State = WaterState.IceAndFluid;
                    return;
                }

            }

            increaseInTemperature = calories / Amount;
            if (Temperature >= 0 &&
                Temperature <= 100 &&
                Temperature + increaseInTemperature >= 100 &&
                (State == WaterState.Fluid || State == WaterState.FluidAndGas))
            {
                calories -= Amount * (100 - Temperature);
                Temperature = 100;

                var amountVaporated = calories / _energyFromLiquidToGas;
                if (amountVaporated >= Amount)
                {
                    State = WaterState.Gas;
                    calories -= Amount * _energyFromLiquidToGas;
                }
                else
                {
                    ProportionFirstState = 1 - amountVaporated / Amount;
                    State = WaterState.FluidAndGas;
                    return;
                }
            }

            increaseInTemperature = calories / Amount;
            Temperature += increaseInTemperature;
        }


    }
}