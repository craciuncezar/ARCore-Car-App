using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComponent {
    public string Name { get; set; }
    public string Description { get; set; }
    public string PossibleMalfunction { get; set; }

    public CarComponent(string name, string description, string possibleMalfunction)
    {
        this.Name = name;
        this.Description = description;
        this.PossibleMalfunction = possibleMalfunction;
    }

    public CarComponent(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }


}
