﻿//-----------------------------------------------------------------
// CourseManager persists between scenes and keeps track of courses
//-----------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CourseManager : MonoBehaviour {

	private static CourseManager _ins;
	public static CourseManager ins {
		get {
			if (_ins == null) {
				_ins = GameObject.FindObjectOfType <CourseManager>();

				DontDestroyOnLoad (_ins.gameObject);
			}
		
			return _ins;
		}
		set {
			_ins = value;
		}
	}

	public int curCourseIndex;
	public List<Course> courseList;

	void Awake () {
		if (_ins == null) {
			// Populate with first instance
			_ins = this;
			DontDestroyOnLoad (this);
		} else {
			// Another instance exists, destroy
			if (this != _ins)
				Destroy (this.gameObject);
		}

		PopulateCourseList ();

		foreach (Course course in courseList) {
			Debug.Log (course.title);
		}
	}

	// Populate the courseList variable with Course assets in the /Courses folder
	public void PopulateCourseList () {
		courseList = CourseUtil.LoadAllCourses ().ToList<Course>();
	}
}