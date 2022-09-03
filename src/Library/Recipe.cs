//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"\nEl Costo total de la receta es de: ${this.GetProductionCost()}\n"); //Agrego el costo total a la impresión de la receta
        }
        public double GetProductionCost() //Método para hacer el costo total
        {
            double insumos = 0;
            double equipamiento = 0;
            double total = 0;
            foreach (Step step in this.steps)
            {
                insumos = insumos + step.Input.UnitCost;
                equipamiento = equipamiento + step.SubTotal(); //Uso el subtotal siguiendo con el patrón Expert
            }
            total = insumos+equipamiento;
            return total;
        }
    }
}