﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Cars.Count; } }
        public Parking(int capacity)
        {
            Cars = new List<Car>(); 
            Capacity = capacity;    
        }
        public string AddCar(Car addedCar)
        {
            bool canAddCar = true;
            foreach (var car in Cars)
            {
                if (car.RegistrationNumber==addedCar.RegistrationNumber)
                {
                    canAddCar = false;
                    return "Car with that registration number, already exists!";               
                }
            }
            if (Cars.Count+1 > Capacity)
            {
                canAddCar = false;
                return"Parking is full!";
  
            }
            if (canAddCar)
            {
                Cars.Add(addedCar);
                return $"Successfully added new car {addedCar.Make} {addedCar.RegistrationNumber}";
            }
            return "";
        }
        public string RemoveCar(string registrationNumber)
        {
            bool isAvalible=false;
            foreach (var car in Cars)
            {
                if (car.RegistrationNumber==registrationNumber)
                {
                    isAvalible = true;
                }
            }
            if (!isAvalible)
            {
               return "Car with that registration number, doesn't exist!";
            }
            else
            {
                var carToRemove=Cars.First(c=>c.RegistrationNumber==registrationNumber);
                Cars.Remove(carToRemove);
              return $"Successfully removed {registrationNumber}";
            }
            return "";
        }
        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(c=>c.RegistrationNumber==registrationNumber);    
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}
