namespace Smart.Forms.Animations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    [ContentProperty("Animations")]
    public sealed class StoryBoard : AnimationBase
    {
        public List<AnimationBase> Animations { get; }

        public StoryBoard()
        {
            Animations = new List<AnimationBase>();
        }

        public StoryBoard(List<AnimationBase> animations)
        {
            Animations = animations;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2007:DoNotDirectlyAwaitATask", Justification = "Ignore")]
        protected override async Task BeginAnimation()
        {
            foreach (var animation in Animations)
            {
                animation.Target ??= Target;

                await animation.Begin();
            }
        }
    }
}
