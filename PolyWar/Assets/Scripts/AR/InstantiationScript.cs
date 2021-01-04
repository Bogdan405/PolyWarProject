using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pairs;

public class InstantiationScript : MonoBehaviour
{
    public GameObject ModelObj = new GameObject();



    UnityEngine.Object UndeadEnchanter = Resources.Load("Assets/Models/UndeadEnchanter");
    UnityEngine.Object EnchanterAnimator = Resources.Load("Assets/Models/EnchanterAnimator");
    //UnityEngine.Object AnimationPlayScript = Resources.Load("Assets/Scripts/AR/AnimationPlayScript");


        /*
    public Object MakeObj(Pair target) {
        if(target.element == Card.Element.Undead){
            if (target.model == Card.Model.Sentry){}
            else if (target.model == Card.Model.Enchanter){

                ModelObj = Instantiate((GameObject)UndeadEnchanter, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                //GameObject.AddComponent(typeof(AnimationPlayScript)) as AnimationPlayScript;
                ModelObj.AddComponent<AnimationPlayScript>();
                // asta still ar trebui facut : ModelObj.AddComponent<EnchanterAnimator>();
                
                
                return ModelObj;
                }
            else if (target.model == Card.Model.Juggernaut){
            
            }
            else if (target.model == Card.Model.Wraith){}
            else if (target.model == Card.Model.LordMantis){}
            else if (target.model == Card.Model.Berserk){}
        }
        else if(target.element == Card.Element.Automaton){
            if (target.model == Card.Model.Sentry){}
            else if (target.model == Card.Model.Enchanter){}
            else if (target.model == Card.Model.Juggernaut){}
            else if (target.model == Card.Model.Wraith){}
            else if (target.model == Card.Model.LordMantis){}
            else if (target.model == Card.Model.Berserk){}
        }
        else if(target.element == Card.Element.Elemental){
            if (target.model == Card.Model.Sentry) { }
            else if (target.model == Card.Model.Enchanter) { }
            else if (target.model == Card.Model.Juggernaut) { }
            else if (target.model == Card.Model.Wraith) { }
            else if (target.model == Card.Model.LordMantis) { }
            else if (target.model == Card.Model.Berserk) { }
        }
        else if(target.element == Card.Element.Chemical){
            if (target.model == Card.Model.Sentry) { }
            else if (target.model == Card.Model.Enchanter) { }
            else if (target.model == Card.Model.Juggernaut) { }
            else if (target.model == Card.Model.Wraith) { }
            else if (target.model == Card.Model.LordMantis) { }
            else if (target.model == Card.Model.Berserk) { }
        }
    }*/
}
