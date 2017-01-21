using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticlePool : MonoBehaviour {

	public GameObject particleFalsePrefabs, particleTruePrefabs;
	public Transform particleParent;
	public List<ParticleSystem> particleFalseList;
	public List<ParticleSystem> particleTrueList;

	public ParticleSystem GetAvailableParticle(bool isRight)
	{
		if (!isRight) {
			for (int i = 0; i < particleFalseList.Count; i++) {
				if (!particleFalseList [i].isPlaying)
					return particleFalseList [i];
			}
			GenerateNewTrueParticle ();
		} else {
			for (int i = 0; i < particleTrueList.Count; i++) {
				if (!particleTrueList [i].isPlaying)
					return particleTrueList [i];
			}
			GenerateNewFalseParticle ();
		}

		return particleFalseList [0];

	}
	public ParticleSystem GenerateNewTrueParticle()
	{
		GameObject particle = Instantiate (particleTruePrefabs, particleParent) as GameObject;
		particle.transform.localScale = Vector3.one;
		ParticleSystem newParticle = particle.GetComponent<ParticleSystem> ();
		particleTrueList.Add (newParticle);
		return newParticle;
	}
	public ParticleSystem GenerateNewFalseParticle()
	{
		GameObject particle = Instantiate (particleFalsePrefabs, particleParent) as GameObject;
		particle.transform.localScale = Vector3.one;
		ParticleSystem newParticle = particle.GetComponent<ParticleSystem> ();
		particleFalseList.Add (newParticle);
		return newParticle;
	}
}
