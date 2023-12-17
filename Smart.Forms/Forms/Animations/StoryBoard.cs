namespace Smart.Forms.Animations;

using Xamarin.Forms;

[ContentProperty("Animations")]
public sealed class StoryBoard : AnimationBase
{
#pragma warning disable CA1002
    public List<AnimationBase> Animations { get; }
#pragma warning restore CA1002

    public StoryBoard()
    {
        Animations = [];
    }

#pragma warning disable CA1002
    public StoryBoard(List<AnimationBase> animations)
    {
        Animations = animations;
    }
#pragma warning restore CA1002

    protected override async Task BeginAnimation()
    {
        foreach (var animation in Animations)
        {
            animation.Target ??= Target;

            await animation.Begin();
        }
    }
}
