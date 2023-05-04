using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SH.ScriptableArchitecture.Editor
{
    public class GeneratorWindow : EditorWindow
    {
        private Object selectedObject;

        [MenuItem("Tools/Scriptable Architecture Generator")]
        private static void OpenWindow()
        {
            GeneratorWindow window = GetWindow<GeneratorWindow>();
            window.titleContent = new GUIContent("Scriptable Architecture Generator");
            window.minSize = new Vector2(300f, 300f);
            window.Show();
        }

        private void CreateGUI()
        {
            CreateGeneratorEditorPrefs();
            rootVisualElement.Add(CreateTitleLabel());
            rootVisualElement.Add(CreateObjectField());
            rootVisualElement.Add(CreateDataPathTextField());
            rootVisualElement.Add(CreateScriptPathTextField());
            rootVisualElement.Add(CreateNamespaceTextField());
            rootVisualElement.Add(CreateContextMenuPathTextField());
            rootVisualElement.Add(CreateSpacerField());
            rootVisualElement.Add(CreateGenerateVariableButtonField());
            rootVisualElement.Add(CreateGenerateEventButtonField());
            rootVisualElement.Add(CreateGenerateListenerButtonField());
            rootVisualElement.Add(CreateResetButtonField());
        }

        private VisualElement CreateTitleLabel()
        {
            Label label = new Label("Scriptable Architecture Generator");
            float padding = 8f;
            label.style.paddingTop = padding;
            label.style.paddingBottom = padding;
            label.style.paddingLeft = padding;
            label.style.paddingRight = padding;
            label.style.unityTextAlign = TextAnchor.MiddleCenter;
            label.style.fontSize = 20f;
            return label;
        }

        private ObjectField CreateObjectField()
        {
            ObjectField objectField = new ObjectField();
            objectField.objectType = typeof(Object);
            objectField.allowSceneObjects = false;
            objectField.RegisterCallback<ChangeEvent<Object>>(evt => selectedObject = evt.newValue);
            objectField.label = "Selected Object";
            return objectField;
        }

        private VisualElement CreateDataPathTextField()
        {
            TextField textField = new TextField();
            textField.value = EditorPrefs.GetString(GeneratorPrefs.DataPathKey);
            textField.RegisterCallback<ChangeEvent<string>>(evt => EditorPrefs.SetString(GeneratorPrefs.DataPathKey, evt.newValue));
            textField.label = "Path for Data";
            return textField;
        }

        private VisualElement CreateScriptPathTextField()
        {
            TextField textField = new TextField();
            textField.value = EditorPrefs.GetString(GeneratorPrefs.ScriptPathKey);
            textField.RegisterCallback<ChangeEvent<string>>(evt => EditorPrefs.SetString(GeneratorPrefs.ScriptPathKey, evt.newValue));
            textField.label = "Path for Script";
            return textField;
        }

        private VisualElement CreateNamespaceTextField()
        {
            TextField textField = new TextField();
            textField.value = EditorPrefs.GetString(GeneratorPrefs.NamespaceKey);
            textField.RegisterCallback<ChangeEvent<string>>(evt => EditorPrefs.SetString(GeneratorPrefs.NamespaceKey, evt.newValue));
            textField.label = "Namespace";
            return textField;
        }

        private VisualElement CreateContextMenuPathTextField()
        {
            TextField textField = new TextField();
            textField.value = EditorPrefs.GetString(GeneratorPrefs.ContextMenuPathKey);
            textField.RegisterCallback<ChangeEvent<string>>(evt => EditorPrefs.SetString(GeneratorPrefs.ContextMenuPathKey, evt.newValue));
            textField.label = "Context Menu Path";
            return textField;
        }

        private VisualElement CreateSpacerField()
        {
            VisualElement spacer = new VisualElement();
            spacer.style.height = 8f;
            return spacer;
        }

        private VisualElement CreateGenerateVariableButtonField()
        {
            Button button = new Button();
            button.clicked += OnCreateVariableButtonClicked;
            button.text = "Generate Variable";
            return button;
        }

        private VisualElement CreateGenerateEventButtonField()
        {
            Button button = new Button();
            button.clicked += OnCreateEventButtonClicked;
            button.text = "Generate Event";
            return button;
        }

        private VisualElement CreateGenerateListenerButtonField()
        {
            Button button = new Button();
            button.clicked += OnCreateListenerButtonClicked;
            button.text = "Generate Listener";
            return button;
        }

        private VisualElement CreateResetButtonField()
        {
            Button button = new Button();
            button.clicked += OnResetButtonClicked;
            button.text = "Reset";
            return button;
        }

        private void CreateGeneratorEditorPrefs()
        {
            if (!EditorPrefs.HasKey(GeneratorPrefs.DataPathKey))
                EditorPrefs.SetString(GeneratorPrefs.DataPathKey, GeneratorPrefs.DataPathValue);

            if (!EditorPrefs.HasKey(GeneratorPrefs.ScriptPathKey))
                EditorPrefs.SetString(GeneratorPrefs.ScriptPathKey, GeneratorPrefs.ScriptPathValue);

            if (!EditorPrefs.HasKey(GeneratorPrefs.NamespaceKey))
                EditorPrefs.SetString(GeneratorPrefs.NamespaceKey, GeneratorPrefs.NamespaceValue);

            if (!EditorPrefs.HasKey(GeneratorPrefs.ContextMenuPathKey))
                EditorPrefs.SetString(GeneratorPrefs.ContextMenuPathKey, GeneratorPrefs.ContextMenuPathValue);
        }

        private void OnResetButtonClicked()
        {
            EditorPrefs.SetString(GeneratorPrefs.DataPathKey, GeneratorPrefs.DataPathValue);
            EditorPrefs.SetString(GeneratorPrefs.ScriptPathKey, GeneratorPrefs.ScriptPathValue);
            EditorPrefs.SetString(GeneratorPrefs.NamespaceKey, GeneratorPrefs.NamespaceValue);
            EditorPrefs.SetString(GeneratorPrefs.ContextMenuPathKey, GeneratorPrefs.ContextMenuPathValue);

            rootVisualElement.Clear();
            CreateGUI();
        }

        private (string ScriptPath, string DataPath, string ObjectName) GetPaths()
        {
            string scriptPath = $"{Application.dataPath}/{EditorPrefs.GetString(GeneratorPrefs.ScriptPathKey)}";
            string dataPath = $"{Application.dataPath}/{EditorPrefs.GetString(GeneratorPrefs.DataPathKey)}";
            string objectName = selectedObject.name;
            return (scriptPath, dataPath, objectName);
        }

        private string FormatTemplate(string template, string objectName)
        {
            template = template.Replace("%NAMESPACE%", EditorPrefs.GetString(GeneratorPrefs.NamespaceKey));
            template = template.Replace("%CONTEXTMENU%", EditorPrefs.GetString(GeneratorPrefs.ContextMenuPathKey));
            template = template.Replace("%NAME%", objectName);
            return template;
        }

        private void OnCreateVariableButtonClicked()
        {
            if (selectedObject == null)
            {
                Debug.LogWarning("No object selected.");
                return;
            }

            var paths = GetPaths();
            string template = GeneratorPrefs.VariableTemplateScript;
            template = FormatTemplate(template, paths.ObjectName);

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}")))
                Directory.CreateDirectory($"{paths.ScriptPath}");

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}/Variables/")))
                Directory.CreateDirectory($"{paths.ScriptPath}/Variables/");

            if (!File.Exists($"{paths.ScriptPath}/Variables/{paths.ObjectName}Variable.cs"))
                File.Create($"{paths.ScriptPath}/Variables/{paths.ObjectName}Variable.cs").Close();

            File.WriteAllText($"{paths.ScriptPath}/Variables/{paths.ObjectName}Variable.cs", template);
            AssetDatabase.Refresh();
        }

        private void OnCreateEventButtonClicked()
        {
            if (selectedObject == null)
            {
                Debug.LogWarning("No object selected.");
                return;
            }

            var paths = GetPaths();
            string template = GeneratorPrefs.EventTemplateScript;
            template = FormatTemplate(template, paths.ObjectName);

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}")))
                Directory.CreateDirectory($"{paths.ScriptPath}");

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}/Events/")))
                Directory.CreateDirectory($"{paths.ScriptPath}/Events/");

            if (!File.Exists($"{paths.ScriptPath}/Events/{paths.ObjectName}ScriptableEvent.cs"))
                File.Create($"{paths.ScriptPath}/Events/{paths.ObjectName}ScriptableEvent.cs").Close();

            File.WriteAllText($"{paths.ScriptPath}/Events/{paths.ObjectName}ScriptableEvent.cs", template);
            AssetDatabase.Refresh();
        }

        private void OnCreateListenerButtonClicked()
        {
            if (selectedObject == null)
            {
                Debug.LogWarning("No object selected.");
                return;
            }

            var paths = GetPaths();
            string template = GeneratorPrefs.ListenerTemplateScript;
            template = FormatTemplate(template, paths.ObjectName);

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}")))
                Directory.CreateDirectory($"{paths.ScriptPath}");

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}/Listeners/")))
                Directory.CreateDirectory($"{paths.ScriptPath}/Listeners/");

            if (!File.Exists($"{paths.ScriptPath}/Listeners/{paths.ObjectName}ScriptableEventListener.cs"))
                File.Create($"{paths.ScriptPath}/Listeners/{paths.ObjectName}ScriptableEventListener.cs").Close();

            File.WriteAllText($"{paths.ScriptPath}/Listeners/{paths.ObjectName}ScriptableEventListener.cs", template);
            AssetDatabase.Refresh();
        }
    }
}