namespace Flash.Widget.Editor
{
    using KarpysDev.KarpysUtils.EditorUtils.SimplePropertyDrawer;
    using UnityEditor;

    [CustomPropertyDrawer(typeof(TweenerEaseCurve))]
    public class TweenerCurveTogglePropertyDrawer : SimpleTogglePropertyDrawer
    {
        protected override string GetBoolPropertyName()
        {
            return "m_UseAnimationCurve";
        }

        protected override string[] GetSwapPropertyNames()
        {
            string[] names = new string[2];
            names[0] = "m_Ease";
            names[1] = "m_AnimationCurve";
            return names;
        }

        protected override string[] GetLabelNames()
        {
            string[] names = new string[3];
            names[0] = "Use Curve";
            names[1] = "Ease";
            names[2] = "Curve";
            return names;
        }
    }
}