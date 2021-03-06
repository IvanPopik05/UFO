using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    public Transform[] points; // Точки объекта
    public Transform obj; // Объект
    public float speed; // Скорость объекта
    public bool cycle; // Цикл движения
    private Transform targetPoint; // Текущая точка
    private int currentPoint; // Количество точек соприкосновения
    private bool forward; // Движение по прямой

    void Start()
    {
        currentPoint = 0;
        targetPoint = points[currentPoint];
        forward = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.position == targetPoint.position)
        {
            if(forward)
            {
                currentPoint++;
            } else
            {
                currentPoint--;
            }

        if(currentPoint >= points.Length && cycle)
            currentPoint = 0;
        else if(currentPoint >= points.Length && !cycle)
        {
            forward = false;
            currentPoint = points.Length - 2;
        }else if(currentPoint < 0)
        {
            forward = true;
            currentPoint = 1;
        }
            targetPoint = points[currentPoint];
        }
        obj.position = Vector3.MoveTowards(obj.position, targetPoint.position, speed * Time.deltaTime);
    }
}
