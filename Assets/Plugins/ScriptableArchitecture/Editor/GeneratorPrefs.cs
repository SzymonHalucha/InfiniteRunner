namespace SH.ScriptableArchitecture.Editor
{
    public static class GeneratorPrefs
    {
        public const string DataPathKey = "ScriptableArchitectureDataPath";
        public const string DataPathValue = "Data/Architecture";

        public const string ScriptPathKey = "ScriptableArchitectureScriptPath";
        public const string ScriptPathValue = "Scripts/Architecture";

        public const string NamespaceKey = "ScriptableArchitectureNamespace";
        public const string NamespaceValue = "Scripts.Architecture";

        public const string ContextMenuPathKey = "ScriptableArchitectureContextMenuPath";
        public const string ContextMenuPathValue = "Architecture";

        public const string VariableTemplateScript =
@"using UnityEngine;
using SH.ScriptableArchitecture.Variables;

namespace %NAMESPACE%.Variables
{
    [CreateAssetMenu(menuName = ""%CONTEXTMENU%/Variables/%NAME%"", fileName = ""New %NAME% Variable"")]
    public class %NAME%Variable : BaseVariable<%NAME%>
    {

    }
}";

        public const string EventTemplateScript =
@"using UnityEngine;
using SH.ScriptableArchitecture.Events;

namespace %NAMESPACE%.Events
{
    [CreateAssetMenu(menuName = ""%CONTEXTMENU%/Events/%NAME%"", fileName = ""New %NAME% Scriptable Event"")]
    public class %NAME%ScriptableEvent : ScriptableEventType1<%NAME%>
    {

    }
}";

        public const string ListenerTemplateScript =
@"using SH.ScriptableArchitecture.Listeners;

namespace %NAMESPACE%.Listeners
{
    public class %NAME%ScriptableEventListener : ScriptableEventType1Listener<%NAME%>
    {

    }
}";
    }
}