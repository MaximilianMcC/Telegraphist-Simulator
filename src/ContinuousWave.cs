using Raylib_cs;

class ContinuousWave
{
	private static bool setBuffer;

	private AudioStream stream;

	private const int buffer = 512;
	private const int sampleRate = 44100;
	private short[] samples;

	//? float isn't precise enough for this
	private double phase;
	private double phaseIncrement;

	public ContinuousWave(double frequency = 440)
	{
		// Ensure that we use the correct buffer size
		if (setBuffer == false)
		{
			Raylib.SetAudioStreamBufferSizeDefault(buffer);
		}

		// Set how fast the sin wave moves (pitch)
		phaseIncrement = frequency / sampleRate;

		// Have a place to store our wave
		samples = new short[buffer];

		// Create a stream for us to put the audio in
		stream = Raylib.LoadAudioStream(sampleRate, 16, 1);
		Raylib.PlayAudioStream(stream);
	}

	public void PlayContinuously()
	{
		// Check for if we need more audio
		if (Raylib.IsAudioStreamProcessed(stream))
		{
			// Populate the buffer with a wave
			for (int i = 0; i < buffer; i++)
			{
				// Get what sound should be made rn
				samples[i] = (short)(Math.Sin(2 * Math.PI * phase) * 32000);

				// Add it to the wave
				phase += phaseIncrement;

				// Check for if we've gotta 'flip' the wave
				if (phase >= 1.0f) phase -= 1.0f;
			}

			// Update the audio
			// TODO: Don't do like this
			unsafe
			{
				fixed (short* samplesPointer = samples)
				{
					Raylib.UpdateAudioStream(stream, samplesPointer, buffer);
				}
			}	
		}
	}

	public void PlaySeconds(float seconds)
	{
		
	}

	public void Unload()
	{
		Raylib.StopAudioStream(stream);
		Raylib.UnloadAudioStream(stream);
	}
}