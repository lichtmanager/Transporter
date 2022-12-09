using ConsoleTables;
using Transporter.Controller;
using Transporter.View;

namespace Transporter.Models;

public class Tender
{
    public Good Good;
    public int Weight;
    public City StartingCity;
    public City EndingCity;
    public string DeliveryDate;
    public double Compensation;
    public double Penalty;


    public Tender(Good good, int weight, City startingCity, City endingCity, string date, double compensation,
        double penalty, string deliveryDate)
    {
        Good = TenderPropertiesController.ChooseRandomGood();
        Weight = weight;
        StartingCity = startingCity;
        EndingCity = endingCity;
        Compensation = compensation;
        Penalty = penalty;
        DeliveryDate = deliveryDate;
    }
}