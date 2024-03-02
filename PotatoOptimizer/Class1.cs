using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace PotatoOptimizer
{
    public class Class1:MelonMod
    {
        GameObject[] crapjects;
        bool IsInMenu => GameObject.FindGameObjectsWithTag("Player").Length <= 0;
        bool cleaned = false;
        public override void OnGUI()
        {
            
        }
        public override void OnUpdate()
        {
            
            if(cleaned && IsInMenu)
            {
                cleaned = false;
            }
            
            if(!cleaned && !IsInMenu)
            {
                cleanbytag("thief");
                cleanbytag("trash");
                cleanbyname("bench");
                cleanbyname("police");
                cleanbyname("saleman");
                cleanbyname("wooden_crate");
                cleanbyname("plasticcover");
                cleanbyname("homeless");
                //cleanbyname("metalbars");
                cleanbyname("dumpster");
                cleanbyname("trashcan");
                cleanbyname("paper");
                cleanbyname("cart");
                cleanbyname("Cardboard");
                cleanbyname("Door_metal");
                cleanbyname("gargabebag");
                cleanbyname("pallete");
                foreach(var shadow in GameObject.FindObjectsOfType<Shader>())
                {
                    shadow.maximumLOD = 0;
                    GameObject.Destroy(shadow);
                }
                foreach(var shadow in GameObject.FindObjectsOfType<VolumetricLight>())
                {
                    if (shadow != null)
                    {
                        shadow.MaxRayLength = 0;
                        shadow.NoiseIntensity = 0;
                        shadow.MieG = 0;
                        shadow.NoiseScale = 0;
                        
                    }
                }
                foreach (var shadow in GameObject.FindObjectsOfType<VolumetricLightRenderer>())
                {
                    if(shadow != null)
                    {
                        shadow.Resolution = VolumetricLightRenderer.VolumtericResolution.Quarter;
                        
                    }
                }
                int maxTextureSize = 64; // Change this to your desired resolution
                
                
                cleaned = true;
            }

        }
        public void cleanbytag(string tag)
        {
            crapjects = GameObject.FindObjectsOfType<GameObject>()
            .Where(obj => obj.tag.ToLower() == tag)
            .ToArray();
            foreach (var crap in crapjects)
            {
                GameObject.Destroy(crap);
            }
        }
        public void KillLightsAndShadows()
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                light.enabled = false;
            }
            QualitySettings.antiAliasing = 0;
            QualitySettings.anisotropicFiltering = 0;
            QualitySettings.masterTextureLimit = 0;
            QualitySettings.SetQualityLevel(0);
            QualitySettings.maximumLODLevel = 0;
            QualitySettings.particleRaycastBudget = 0;
            QualitySettings.shadowDistance = 0;
            QualitySettings.shadowResolution = ShadowResolution.Low;
            QualitySettings.shadowCascades = 0;
            QualitySettings.shadows = ShadowQuality.Disable;
            QualitySettings.softParticles = false;
            QualitySettings.pixelLightCount = 0;
        }
        public void cleanbyname(string name)
        {
            crapjects = GameObject.FindObjectsOfType<GameObject>()
            .Where(obj => obj.name.ToLower().Contains(name.ToLower()))
            .ToArray();
            foreach(var crap in crapjects)
            {
                GameObject.Destroy(crap);
            }
        }
    }
}
