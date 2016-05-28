using UnityEngine;
using System.Collections;

[System.SerializableAttribute]
public class Command
{
    public float delay;
}

[System.SerializableAttribute]
public class TweenCommand: Command
{
    public float tweenTime;
    public Vector2 tweenPosition;
}

[System.SerializableAttribute]
public class ScaleCommand: Command
{
    public float scaleTime;
    public Vector2 scaleVector;
}

[System.SerializableAttribute]
public class ChangeSpriteCommand: Command
{
    public Sprite newSprite;
}

public class CommandExecuter : MonoBehaviour 
{
	public void ExecuteCommand(Command command)
	{
		if(command != null)
		{
			if(command is TweenCommand)
			{
				ExecuteTweenCommand(command as TweenCommand);
			}
			else if(command is ScaleCommand)
			{
				ExecuteScaleCommand(command as ScaleCommand);
			}
			else if(command is ChangeSpriteCommand)
			{
				ExecuteChangeSpriteCommand(command as ChangeSpriteCommand);
			}
		}
	}
	
	private void ExecuteTweenCommand(TweenCommand command)
	{
        LeanTween.move(gameObject, command.tweenPosition, command.tweenTime).setDelay(command.delay).setEase(LeanTweenType.easeInOutQuad);;
	}
	
	private void ExecuteScaleCommand(ScaleCommand command)
	{
        if (command.scaleVector != Vector2.zero)
        {
            LeanTween.scale(gameObject, command.scaleVector, command.scaleTime).setDelay(command.delay).setEase(LeanTweenType.easeInOutQuad);;
        }
    }
	
	private void ExecuteChangeSpriteCommand(ChangeSpriteCommand command)
	{
        if (command.newSprite != null)
        {
            StartCoroutine(WaitForChangeSprite(command));
        }
    }

    private IEnumerator WaitForChangeSprite(ChangeSpriteCommand command)
    {
        yield return new WaitForSeconds(command.delay);
        gameObject.GetComponent<SpriteRenderer>().sprite = command.newSprite;
    }
}
