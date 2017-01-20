using UnityEngine;
using System;

public class Mathfx {
	public static float Hermite(float start, float end, float time) {
		return Mathf.Lerp(start, end, time * time * (3.0f - 2.0f * time));
	}

	public static float Sinerp(float start, float end, float time) {
		return Mathf.Lerp(start, end, Mathf.Sin(time * Mathf.PI * 0.5f));
	}

	public static float Coserp(float start, float end, float time) {
		return Mathf.Lerp(start, end, 1.0f - Mathf.Cos(time * Mathf.PI * 0.5f));
	}

	public static float Clerp(float start, float end, float time) {
		float min = 0.0f;
		float max = 360.0f;
		float half = Mathf.Abs((max - min) / 2.0f);
		float retval = 0.0f;
		float diff = 0.0f;

		if ((end - start) < -half) {
			diff = ((max - start) + end) * time;
			retval = start + diff;
		}
		else if ((end - start) > half) {
			diff = -((max - end) + start) * time;
			retval = start + diff;
		}
		else retval = start + (end - start) * time;

		return retval;
	}

	public static float Linear(float start, float end, float time) {
		return Mathf.Lerp(start, end, time);
	}

	public static Vector3 Linear(Vector3 start, Vector3 end, float time) {
		return new Vector3(Mathf.Lerp(start.x, end.x, time), 
			Mathf.Lerp(start.y, end.y, time), Mathf.Lerp(start.z, end.z, time));
	}

	public static float Spring(float start, float end, float time) {
		time = Mathf.Clamp01(time);
		time = (Mathf.Sin(time * Mathf.PI * (0.2f + 2.5f * time * time * time)) * Mathf.Pow(1f - time, 2.2f) + time) * (1f + (1.2f * (1f - time)));

		return start + (end - start) * time;
	}

	public static float EaseInQuad(float start, float end, float time) {
		end -= start;
		return end * time * time + start;
	}

	public static float EaseOutQuad(float start, float end, float time) {
		end -= start;
		return -end * time * (time - 2) + start;
	}

	public static float EaseInOutQuad(float start, float end, float time) {
		time /= .5f;
		end -= start;

		if (time < 1) {
			return end / 2 * time * time + start;
		}

		time--;
		return -end / 2 * (time * (time - 2) - 1) + start;
	}

	public static float EaseInCubic(float start, float end, float time) {
		end -= start;
		return end * time * time * time + start;
	}

	public static Vector3 EaseInCubic(Vector3 start, Vector3 end, float time) {
		return new Vector3(EaseInCubic(start.x, end.x, time),
			EaseInCubic(start.y, end.y, time),
			EaseInCubic(start.z, end.z, time));
	}

	public static float EaseOutCubic(float start, float end, float time) {
		time--;
		end -= start;

		return end * (time * time * time + 1) + start;
	}

	public static Vector3 EaseOutCubic(Vector3 start, Vector3 end, float time) {
		return new Vector3(EaseOutCubic(start.x, end.x, time),
			EaseOutCubic(start.y, end.y, time),
			EaseOutCubic(start.z, end.z, time));
	}

	public static float EaseInOutCubic(float start, float end, float time) {
		time /= .5f;
		end -= start;
		if (time < 1) {
			return end / 2 * time * time * time + start;
		}

		time -= 2;
		return end / 2 * (time * time * time + 2) + start;
	}

	public static float EaseInQuart(float start, float end, float time) {
		end -= start;
		return end * time * time * time * time + start;
	}

	public static float EaseOutQuart(float start, float end, float time) {
		time--;
		end -= start;

		return -end * (time * time * time * time - 1) + start;
	}

	public static float EaseInOutQuart(float start, float end, float time) {
		time /= .5f;
		end -= start;

		if (time < 1) {
			return end / 2 * time * time * time * time + start;
		}

		time -= 2;
		return -end / 2 * (time * time * time * time - 2) + start;
	}

	public static float EaseInQuint(float start, float end, float time) {
		end -= start;
		return end * time * time * time * time * time + start;
	}

	public static float EaseOutQuint(float start, float end, float time) {
		time--;
		end -= start;

		return end * (time * time * time * time * time + 1) + start;
	}

	public static Vector3 EaseOutQuint(Vector3 start, Vector3 end, float time) {
		return new Vector3(EaseOutQuint(start.x, end.x, time),
			EaseOutQuint(start.y, end.y, time),
			EaseOutQuint(start.z, end.z, time));
	}

	public static float EaseInOutQuint(float start, float end, float time) {
		time /= .5f;
		end -= start;

		if (time < 1) {
			return end / 2 * time * time * time * time * time + start;
		}

		time -= 2;
		return end / 2 * (time * time * time * time * time + 2) + start;
	}

	public static float EaseInSine(float start, float end, float time) {
		end -= start;
		return -end * Mathf.Cos(time / 1 * (Mathf.PI / 2)) + end + start;
	}

	public static float EaseOutSine(float start, float end, float time) {
		end -= start;
		return end * Mathf.Sin(time / 1 * (Mathf.PI / 2)) + start;
	}

	public static float EaseInOutSine(float start, float end, float time) {
		end -= start;
		return -end / 2 * (Mathf.Cos(Mathf.PI * time / 1) - 1) + start;
	}

	public static float EaseInExpo(float start, float end, float time) {
		end -= start;
		return end * Mathf.Pow(2, 10 * (time / 1 - 1)) + start;
	}

	public static float EaseOutExpo(float start, float end, float time) {
		end -= start;
		return end * (-Mathf.Pow(2, -10 * time / 1) + 1) + start;
	}

	public static float EaseInOutExpo(float start, float end, float time) {
		time /= .5f;
		end -= start;
		if (time < 1) {
			return end / 2 * Mathf.Pow(2, 10 * (time - 1)) + start;
		}

		time--;
		return end / 2 * (-Mathf.Pow(2, -10 * time) + 2) + start;
	}

	public static float EaseInCirc(float start, float end, float time) {
		end -= start;
		return -end * (Mathf.Sqrt(1 - time * time) - 1) + start;
	}

	public static float EaseOutCirc(float start, float end, float time) {
		time--;
		end -= start;
		return end * Mathf.Sqrt(1 - time * time) + start;
	}

	public static float EaseInOutCirc(float start, float end, float time) {
		time /= .5f;
		end -= start;
		if (time < 1) {
			return -end / 2 * (Mathf.Sqrt(1 - time * time) - 1) + start;
		}

		time -= 2;
		return end / 2 * (Mathf.Sqrt(1 - time * time) + 1) + start;
	}

	public static float Bounce(float start, float end, float time) {
		time /= 1f;
		end -= start;
		if (time < (1 / 2.75f)) {
			return end * (7.5625f * time * time) + start;
		}
		else if (time < (2 / 2.75f)) {
			time -= (1.5f / 2.75f);
			return end * (7.5625f * (time) * time + .75f) + start;
		}
		else if (time < (2.5 / 2.75)) {
			time -= (2.25f / 2.75f);
			return end * (7.5625f * (time) * time + .9375f) + start;
		}
		else {
			time -= (2.625f / 2.75f);
			return end * (7.5625f * (time) * time + .984375f) + start;
		}
	}

	public static float EaseInBack(float start, float end, float time) {
		end -= start;
		time /= 1;
		float s = 1.70158f;

		return end * (time) * time * ((s + 1) * time - s) + start;
	}

	public static float EaseOutBack(float start, float end, float time) {
		float s = 1.70158f;
		end -= start;
		time = (time / 1) - 1;

		return end * ((time) * time * ((s + 1) * time + s) + 1) + start;
	}

	public static float EaseInOutBack(float start, float end, float time) {
		float s = 1.70158f;
		end -= start;
		time /= .5f;
		if ((time) < 1) {
			s *= (1.525f);
			return end / 2 * (time * time * (((s) + 1) * time - s)) + start;
		}

		time -= 2;
		s *= (1.525f);

		return end / 2 * ((time) * time * (((s) + 1) * time + s) + 2) + start;
	}

	public static float Punch(float amplitude, float time) {
		float s = 9;
		if (time == 0) {
			return 0;
		}

		if (time == 1) {
			return 0;
		}

		float period = 1 * 0.3f;
		s = period / (2 * Mathf.PI) * Mathf.Asin(0);

		return (amplitude * Mathf.Pow(2, -10 * time) * Mathf.Sin((time * 1 - s) * (2 * Mathf.PI) / period));
	}

	public static float Elastic(float start, float end, float time) {
		end -= start;

		float d = 1f;
		float p = d * .3f;
		float s = 0;
		float a = 0;

		if (time == 0) {
			return start;
		}

		if ((time /= d) == 1) {
			return start + end;
		}

		if (a == 0f || a < Mathf.Abs(end)) {
			a = end;
			s = p / 4;
		}
		else {
			s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
		}

		return (a * Mathf.Pow(2, -10 * time) * Mathf.Sin((time * d - s) * (2 * Mathf.PI) / p) + end + start);
	}	

	public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max) {
		return new Vector3(Mathf.Clamp(value.x, min.x, max.x), 
			Mathf.Clamp(value.y, min.y, max.y),
			Mathf.Clamp(value.z, min.z, max.z));
	}

	public static Vector3 RoundToInt(Vector3 value) {
		return new Vector3(Mathf.RoundToInt(value.x), 
			Mathf.RoundToInt(value.y),
			Mathf.RoundToInt(value.z));
	}

	public static Vector3 RandomRange(Vector3 min, Vector3 max) {
		return new Vector3(UnityEngine.Random.Range(min.x, max.x), 
			UnityEngine.Random.Range(min.y, max.y), 
			UnityEngine.Random.Range(min.z, max.z));
	}

	public static Color GetColor(Vector3 color) {
		return new Color(color.x, color.y, color.z);
	}
}