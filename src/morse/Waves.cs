interface Effect;

abstract class WaveEffect : Effect
{
	protected double strength;
	public WaveEffect(double strength = 1d)
	{
		this.strength = strength;
	}

	public abstract double GenerateSample(double phase);
}

class SineWave : WaveEffect
{
	public SineWave(double strength = 1) : base(strength) { }

	public override double GenerateSample(double phase)
	{
		double sample = Math.Sin((2f * Math.PI) * phase);
		return sample * strength;
	}
}

class SawtoothWave : WaveEffect
{
	public SawtoothWave(double strength = 1) : base(strength) { }

	public override double GenerateSample(double phase)
	{
		double sample = (2f * phase) - 1f;
		return sample * strength;
	}
}