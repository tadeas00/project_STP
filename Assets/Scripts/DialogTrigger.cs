using System.Collections.Generic;
using UnityEngine;
 
public class DialogueTrigger : Collidable
{
    public Dialogue dialogue;
 
    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    public static class BoolHolder
    {
        public static bool dialogueTriggered = false;
    }
 
    protected override void OnCollide(Collider2D coll)
    {
        if (!BoolHolder.dialogueTriggered && coll.tag == "Fighter")
        {
            TriggerDialogue();
            BoolHolder.dialogueTriggered = true;
        }
    }
}

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}
 
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}