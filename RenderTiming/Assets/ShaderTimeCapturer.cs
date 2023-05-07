using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RenderTiming;

[RequireComponent(typeof(RenderTiming))]
public class ShaderTimeCapturer : MonoBehaviour
{
    List<ShaderTiming> timings;

    bool sorting = false;

    bool show = false;

    GUIStyle style;
    GUILayoutOption[] options;

    private void OnGUI()
    {
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.button);
            style.fontSize = Convert.ToInt32(24.0f / 1080 * Screen.width);
        }

        if (options == null)
        {
            options = new[] { GUILayout.Width(128.0f / 1080 * Screen.width) };
        }

        {
            GUILayout.BeginVertical();

            {
                GUILayout.BeginHorizontal();

                if (GUILayout.Button("Show", style))
                {
                    show = !show;

                    if (show)
                    {
                        StartCoroutine(CoroutineCapture());
                    }
                }

                if (!show)
                {
                    GUILayout.EndHorizontal();
                    GUILayout.EndVertical();

                    return;
                }

                if (RenderTiming.instance != null && RenderTiming.instance.enabled)
                {
                    if (GUILayout.Button("Refresh", style))
                    {
                        StartCoroutine(CoroutineCapture());
                    }

                    if (GUILayout.Button($"Sorting: {sorting}", style))
                    {
                        sorting = !sorting;

                        StartCoroutine(CoroutineCapture());
                    }
                }

                GUILayout.EndHorizontal();
            }

            if (timings != null)
            {
                foreach (var timing in timings)
                {
                    GUILayout.BeginHorizontal();

                    GUILayout.Label($"{timing.Time,8:f5}", style, options);
                    GUILayout.Label($"{timing.FragmentName}", style);
                    GUILayout.Label($"{timing.VertexName}", style);

                    GUILayout.EndHorizontal();
                }
            }

            GUILayout.EndHorizontal();
        }
    }

    private IEnumerator CoroutineCapture()
    {
        yield return new WaitForEndOfFrame();
        timings = GetShaderTimings(sorting);
    }
}
