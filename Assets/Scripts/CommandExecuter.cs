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

[System.SerializableAttribute]
public class MakeTransparentCommand : Command
{
    public float duration;
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
			else if (command is MakeTransparentCommand)
            {
                ExecuteMakeTransparent(command as MakeTransparentCommand);
            }
        }
	}
	
	private void ExecuteTweenCommand(TweenCommand command)
	{
        LeanTween.move(gameObject, command.tweenPosition, command.tweenTime).setDelay(command.delay).setEase(LeanTweenType.easeInOutQuad);
	}
	
	private void ExecuteScaleCommand(ScaleCommand command)
	{
        if (command.scaleVector != Vector2.zero)
        {
            LeanTween.scale(gameObject, command.scaleVector, command.scaleTime).setDelay(command.delay).setEase(LeanTweenType.easeInOutQuad);
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

    private void ExecuteMakeTransparent(MakeTransparentCommand command)
    {
       	LeanTween.alpha(gameObject, 0, command.duration).setDelay(command.delay).setEase(LeanTweenType.easeInOutQuad);

        if (transform.childCount > 0)
        {
            LeanTween.alpha(gameObject.transform.GetChild(0).gameObject, 1, command.duration).setDelay(command.delay).setEase(LeanTweenType.easeInOutQuad);
        }
    }
}
