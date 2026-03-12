namespace CustomException_Assignment
{
    public class Vehicle
    {
        public const int MAXIMUM_SPEED_LIMIT = 100;
        private int currentSpeed;

        public Vehicle(int currentSpeed)
        {
            this.currentSpeed = currentSpeed;
        }

        public int IncreaseSpeed(int speedValue)
        {
            currentSpeed += speedValue;

            if (currentSpeed >= MAXIMUM_SPEED_LIMIT)
                throw new MaximumSpeedLimitCrossedException($"current speed: {currentSpeed} has crossed maximum speed limit of {MAXIMUM_SPEED_LIMIT}");

            return currentSpeed;
        }
    }
}
