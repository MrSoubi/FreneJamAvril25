using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("DSO_Attractor"), menuName = "DSO/Attractor")]
public class DSO_Attractor : DataScriptableObject<AttractorBehavior>
{
    public List<Rigidbody> m_Rigidbodies = new List<Rigidbody>();
}