using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

/// <summary>
/// URL:http://answers.unity3d.com/questions/221651/yielding-with-www-in-editor.html
/// </summary>
internal class ContinuationManager
{
    private class Job
    {
        public Job(Func<bool> completed, Action continueWith)
        {
            Completed = completed;
            ContinueWith = continueWith;
        }
        public Func<bool> Completed { get; private set; }
        public Action ContinueWith { get; private set; }
    }

    private readonly List<Job> jobs = new List<Job>();

    private int maxCount = 0;
    private int completeCount = 0;

    public float Progress
    {
        get { return completeCount != 0 ? completeCount / maxCount : 0f; }
    }

    public bool IsDone
    {
        get { return jobs.Count <= 0; }
    }

    public void Add(Func<bool> completed, Action continueWith)
    {
        if (!jobs.Any()) EditorApplication.update += Update;
        jobs.Add(new Job(completed, continueWith));
    }

    private void Update()
    {
        if (maxCount <= jobs.Count) maxCount = jobs.Count;
        for (int i = 0; i >= 0; --i)
        {
            var jobIt = jobs[i];
            if (jobIt.Completed())
            {
                jobIt.ContinueWith();
                jobs.RemoveAt(i);
                completeCount++;
            }
        }
        if (!jobs.Any()) EditorApplication.update -= Update;
    }
}