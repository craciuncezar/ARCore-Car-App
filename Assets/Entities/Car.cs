using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car{
    public string Description { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
    public string ModelReference { get; set; }
    public List<Guide> guides { get; set; }
    public Dictionary<string, CarComponent> carComponents { get; set; }

    public Car(string manufacturer, string model, double price, string description)
    {
        this.Manufacturer = manufacturer;
        this.Model = model;
        this.Price = price;
        this.Description = description;
        this.ModelReference = manufacturer + model;
        guides = new List<Guide>();
    }

    public static Car dummyCar()
    {
        Car dummyCar = new Car("BMW", "M6", 126000, "A very fast car from BMW");

        // Change tire guide
        List<InstructionStep> instructions = new List<InstructionStep>();
        instructions.Add(new InstructionStep("1. Find a flat, stable and safe place to change your tire. You should have a solid, level surface that will restrict the car from rolling. If you are near a road, park as far from traffic as possible and turn on your emergency flashers (hazard lights).", "Stable"));
        instructions.Add(new InstructionStep("2. Apply the parking brake and put car into Park position. If you have a standard transmission, put your vehicle in first or reverse.", "Park"));
        instructions.Add(new InstructionStep("3. Place a heavy object (e.g., rock, concrete, spare wheel, etc.) in front of the front and back tires.", "BlockTire"));
        instructions.Add(new InstructionStep("4. Take out the spare tire and the jack. Place the jack under the frame near the tire that you are going to change. Ensure that the jack is in contact with the metal portion of your car's frame.", "CarJack"));
        instructions.Add(new InstructionStep("5. Raise the jack until it is supporting (but not lifting) the car. The jack should be firmly in place against the underside of the vehicle.Check to make sure that the jack is perpendicular to the ground.", "CarJack2"));
        instructions.Add(new InstructionStep("6. Remove the hubcap and loosen the nuts by turning counterclockwise. Don't take them all the way off; just break the resistance. By keeping the wheel on the ground when you first loosen the nuts, you'll make sure that you're turning the nuts instead of the wheel.", "Unscrew"));
        instructions.Add(new InstructionStep("7. Pump or crank the jack to lift the tire off the ground. You need to lift it high enough to remove the flat tire and replace it with a spare.", "CarJack3"));
        instructions.Add(new InstructionStep("8. Remove the nuts the rest of the way. Turn them counterclockwise until they are loose. Repeat with all lug nuts, then remove the nuts completely.", "Unscrew"));
        instructions.Add(new InstructionStep("9. Remove the tire. Place the flat tire under the vehicle so in the event of a jack failure the vehicle will fall on the old wheel, hopefully preventing injury. If the jack is placed on a flat, solid base, you shouldn't have any problems.", "TireOut"));
        instructions.Add(new InstructionStep("10. Place the spare tire on the hub. Take care to align the rim of the spare tire with the wheel bolts, then put on the lug nuts.", "TireIn"));
        instructions.Add(new InstructionStep("11. Lower the car without applying full weight on the tire. Tighten the nuts as much as possible.", "Screw"));
        instructions.Add(new InstructionStep("12. Lower the car to the ground fully and remove the jack. Finish tightening the nuts.", "Screw2"));
        Guide schimbaRoata = new Guide("Change tire", "You'll need the spare tire, a jack and a lug wrench. In many newer cars, the lug wrench is in the handle of the jack.", instructions);

        // Add oil guide
        instructions = new List<InstructionStep>();
        instructions.Add(new InstructionStep("1. Check the oil after the car has rested for 5 minutes on an even surface. If you check the oil right after turning the car off you will get an inaccurate reading, as some of the oil will still be at the top of the engine.", "EvenSurface"));
        instructions.Add(new InstructionStep("2. Pop the hood of the car. Pull the small lever near the driver's seat to unlock the hood. From there, run your hand between the hood and the body of the car until you find a small lever, usually in the middle of the hood, and press it to completely free the hood.", "PopHood"));
        instructions.Add(new InstructionStep("3. Locate the car's dipstick. Is small, usually yellow cap often labeled as Engine Oil. Wipe the dipstick, and reinsert it and pull it out to check your oil level. Some vehicles don't have a dipstick because the oil level is checked electronically", "Dipstick"));
        instructions.Add(new InstructionStep("4. Check the amount of oil. There should be two small dots on the end of most dipsticks, and one corresponds to the maximum fill line in the oil pan and the other refers to the minimum. In a properly filled car the line should be about halfway between the two points.", "CheckLevelOil"));
        instructions.Add(new InstructionStep("5. Before you try to add oil, you need to find out what kind of oil your car requires. It's generally unwise to mix different grades of oil, so check carefully with the manual or your local mechanic before you add oil to the car.", "OilTank"));
        instructions.Add(new InstructionStep("6. Locate the oil fill cap located on top of your engine. Remove the cap, wipe it off with a paper towel or the rag you've been using, and insert a clean funnel. Add oil in small increments. Check oil and repeat until appropiate amount of oil show on dipstick.", "AddTheOil"));
        Guide adaugaUlei = new Guide("Add oil", "You will need oil.", instructions);

        // Add windshield fluid guide
        instructions = new List<InstructionStep>();
        instructions.Add(new InstructionStep("1. Choose a type of windshield washer fluid. In order to be effective, it’s important that you not use just water in your windshield washer fluid. Regular windshield washer fluid is designed to prevent streaking and not to freeze if the temperature gets too cold.", "ChoseWindshieldFluid"));
        instructions.Add(new InstructionStep("2. Pop the hood of the car. Pull the small lever near the driver's seat to unlock the hood. From there, run your hand between the hood and the body of the car until you find a small lever, usually in the middle of the hood, and press it to completely free the hood.", "PopHood"));
        instructions.Add(new InstructionStep("3. Locate the windshield washer fluid reservoir. The windshield washer fluid reservoir will be marked with a symbol that looks like windshield with wipers moving.", "FindWindshieldCap"));
        instructions.Add(new InstructionStep("4. Open the cap and set it aside. Twist the cap counter-clockwise to unscrew it and lift it off of the reservoir. Set the cap aside someplace safe. Be sure you don’t put it down in dirt or debris so nothing accidentally falls into the fluid when you return the cap.", "UnscrewWindshield"));
        instructions.Add(new InstructionStep("5. Add windshield washer fluid until it reaches the full line. Use a funnel to pour fluid into the reservoir until it reaches the “full” line on the side. Because fluid can expand when heated, it’s important that you do not overfill the reservoir.", "AddWindshield"));
        instructions.Add(new InstructionStep("6. Screw the cap back into place. With the reservoir filled with washer fluid, pick the cap up from where you stored it. Use a rag or paper towels to wipe the cap down to ensure there is no dirt or debris stuck to it.", "ScrewWindshield"));
        Guide adaugaLichidParbriz = new Guide("adaugaLichidParbriz", "You will need oil.", instructions);

        dummyCar.guides.Add(schimbaRoata);
        dummyCar.guides.Add(adaugaUlei);
        dummyCar.guides.Add(adaugaLichidParbriz);

        // Car Components
        Dictionary<string, CarComponent> carComponents = new Dictionary<string, CarComponent>();

        // Enginebay
        carComponents.Add("Engine", new CarComponent("Engine", "An engine or motor is a machine designed to convert one form of energy into mechanical energy.[1][2] Heat engines burn a fuel to create heat which is then used to do work. Electric motors convert electrical energy into mechanical motion; pneumatic motors use compressed air." +
            "\n\nThe purpose of a gasoline car engine is to convert gasoline into motion so that your car can move. Currently the easiest way to create motion from gasoline is to burn the gasoline inside an engine. Therefore, a car engine is an internal combustion engine -- combustion takes place internally." +
            "\n\nThere are different kinds of internal combustion engines. Diesel engines are one form and gas turbine engines are another."));
        carComponents.Add("Jump-starting, positive battery terminal", new CarComponent("Jump-starting, positive battery terminal", "If your battery has died, you may be able to use jumper cables to jump start it from some other vehicle. If you can safely use jumper cables on your vehicle, make sure that the battery on the other vehicle has at least as much voltage as your own. As long as you hook up the cables properly, it doesn’t matter whether your vehicle has negative ground and the GS’s vehicle has positive ground, or your vehicle has an alternator and the GS’s vehicle has a generator."));
        carComponents.Add("Coolant reservoir", new CarComponent("Coolant reservoir", "Car engines create a great deal of energy by burning petrol or diesel. Some of this energy is used to move the vehicle forward (around one third), the other two thirds of the energy produced is converted to heat. Around half of this heat goes out of the exhaust, whilst the remaining heat remains inside the engine block. \n\n Car engines need a way of cooling down else they will continue to increase in temperature until the working metal components inside will begin to literally melt, fuse together and the engine will seize. Engine coolant is a water based liquid that absorbs the heat from the engine."));
        carComponents.Add("Washer fluid reservoir", new CarComponent("Washer fluid reservoir", "Windshield washer fluid is a fluid for motor vehicles that is used in cleaning the windshield with the windshield wiper while the vehicle is being driven.\n\nA control within the car can be operated to spray washer fluid onto the windshield, typically using an electrical pump via jets mounted either beneath the windshield or beneath the wiper blade(s). The windshield wipers are automatically turned on, cleaning dirt and debris off the windshield. Some vehicles use the same method to clean the rear window or the headlights."));
        carComponents.Add("Oil filler neck", new CarComponent("Oil filler neck", "Motor oil, engine oil, or engine lubricant is any of various substances comprising base oils enhanced with additives, particularly antiwear additive plus detergents, dispersants and, for multi-grade oils viscosity index improvers. In addition to that, almost all lubricating oils contain corrosion (GB: rust) and oxidation inhibitors. Motor oil is used for lubrication of internal combustion engines. The main function of motor oil is to reduce friction and wear on moving parts and to clean the engine from sludge (one of the functions of dispersants) and varnish (detergents). It also neutralizes acids that originate from fuel and from oxidation of the lubricant (detergents), improves sealing of piston rings, and cools the engine by carrying heat away from moving parts."));

        // Interior
        carComponents.Add("Releasing the hood lever", new CarComponent("Releasing the hood lever", "Opening the hood on your vehicle is a streamlined procedure with the double pull hood release lever. Pulling the hood release once will pop the hood but doesn't unlatch it, to unlatch the hood simply pull the release a second time and the hood can be lifted open."));
        carComponents.Add("Seat control", new CarComponent("Seat control", "Using the seat control you can control moving the seat forward or backward or the height, the angle of the seat bottom can be twist also in either direction. The backrest can also be tilt to move forward or backward. On some models the seat settings can be saved for multiple users."));
        carComponents.Add("Turn signal control", new CarComponent("Turn signal control", "Press up or down on the stock past the point of resistence, when doing so the corresponding turn signal will continually flash until you either complete your turn or deactivate the blinker."));
        carComponents.Add("Steering wheel", new CarComponent("Steering wheel", "The stearing wheels contains the horn in the middle and depending on the model it can contain buttons for multiple actions like control the radio, or using the voice command system or answering the bluethooth connected phone. All these options have the purpose to keep the driver focused on the road while keeping both hands on the steering wheel."));
        carComponents.Add("Lights control", new CarComponent("Lights control", "There are 4 settings for the headlights:\n\n-Lamps off, daytime running lights; \n\n-Parking lamps and daytime running lights; \n\n-Low beams, welcome lamps; \n\n-Automatic headlamp control, daytime running lights, welcome lamps, High - beam Assistant, Adaptive Light Control."));
        carComponents.Add("Windows and mirrors control", new CarComponent("Windows and mirrors control", "Functions:\n\n-Opening and closing windows;\n\n-Folding exterior mirrors in and out;\n\n-Adjusting exterior mirrors, automatic curb monitor."));
        carComponents.Add("Gauge cluster", new CarComponent("Gauge cluster", "On the cluster you can find the speedometer, indicators for different state of the car components and possible warnings. There is also an indicator for the fuel and an display containing informations for the temperature, clock, and other usefull informations about the car."));
        carComponents.Add("Gear shift", new CarComponent("Gear shift", "Gear shift is a metal lever attached to the shift assembly in a manual transmission-equipped automobile and is used to change gears. In an automatic transmission-equipped vehicle, a similar device is known as a gear selector. A gear stick will normally be used to change gear whilst depressing the clutch pedal with the left foot to disengage the engine from the drivetrain and wheels. Automatic transmission vehicles, semi-automatic transmissions, and those with continuously variable transmission gearboxes do not require a clutch pedal."));
        carComponents.Add("Controller for display system", new CarComponent("Controller for display system", "The controller is used in order to navigate through the display system menu."));
        carComponents.Add("Navigation and control display", new CarComponent("Navigation and control display", "The control and navigation display will provide geolocation information, present informations regarding the car state or just displaying the radio/songs playing."));
        carComponents.Add("Radio control", new CarComponent("Radio control", "Functionality of the radio control is to switching audio sources on/off and adjusting volume and change the media storage (CDs/USB/MicroSD)."));
        carComponents.Add("Climate control", new CarComponent("Climate control", "The driver/passanger can choose the climate settings for different sides of the car or for the entire car. Defrosting windows and removing condensation. Or turning on/off the seat heating functionality."));
        carComponents.Add("Windshield wipers control", new CarComponent("Windshield wipers control", "The wiper control manages the speed that the wipers are moving. Some cars have an auto mode that can change the speed automatically accordingly to the rain hitting the windshield."));

        dummyCar.carComponents = carComponents;
        return dummyCar;
    }

}
