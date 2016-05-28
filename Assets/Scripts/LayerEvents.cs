using UnityEngine;
using System.Collections;

public enum EventTrigger
{
    onMoveForward,
    onMoveBackward
}

[System.SerializableAttribute]
public class CommandList
{
    public ObjectCommand[] commandArray;
}

[System.SerializableAttribute]
public class ObjectCommand
{
    public GameObject goTarget;
    public TweenCommand tweenCommand;
    public ScaleCommand scaleCommand;
    public ChangeSpriteCommand changeSpriteCommand;
}

public class LayerEvents : MonoBehaviour
{
    public CommandList onMoveForwardCommandList;
    public CommandList onMoveBackwardCommandList;

    public void ExecuteCommandList(EventTrigger trigger)
    {
        CommandList list = GetListToExecute(trigger);
        
        if(list != null)
        {
            foreach (ObjectCommand objCommand in list.commandArray)
            {
                objCommand.goTarget.GetComponent<CommandExecuter>().ExecuteCommand(objCommand.tweenCommand);
                objCommand.goTarget.GetComponent<CommandExecuter>().ExecuteCommand(objCommand.scaleCommand);
                objCommand.goTarget.GetComponent<CommandExecuter>().ExecuteCommand(objCommand.changeSpriteCommand);
            }
        }
    }
    
    private CommandList GetListToExecute(EventTrigger trigger)
    {
        CommandList list = null;
        
        if(trigger == EventTrigger.onMoveForward)
        {
            list = onMoveForwardCommandList;
        }
        else if(trigger == EventTrigger.onMoveBackward)
        {
            list = onMoveBackwardCommandList;
        }
        
        return list;
    }
}
