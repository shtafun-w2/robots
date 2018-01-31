
namespace Robots.SDK
{
    public interface IRobot
    {
        void Move(double distance);
        void Turn(double angle);
        void Beep();

        double Distance { get; }
        double Angle { get; }
        int BeepCount { get; }
    }
}
