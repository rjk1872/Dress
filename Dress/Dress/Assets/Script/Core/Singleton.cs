﻿using System;
using System.Reflection;

public class Singleton<T> where T : class
{
    private static T instance;
    private static object initLock = new object();

    public static T GetInstance()
    {
        if (instance == null)
        {
            CreateInstance();
        }

        return instance;
    }

    private static void CreateInstance()
    {
        lock (initLock)
        {
            if (instance == null)
            {
                Type t = typeof(T);

                // Ensure there are no public constructors...
                ConstructorInfo[] ctors = t.GetConstructors();
                if (ctors.Length > 0)
                {
                    throw new InvalidOperationException(String.Format("{0} has at least one accesible ctor making it" +
                                                                      " impossible to enforce singleton behaviour", t.Name));
                }

                // Create an instance via the private constructor
                instance = (T)Activator.CreateInstance(t, true);
            }
        }
    }
}