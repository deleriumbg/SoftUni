const Car = require('../models/Car');
const Rent = require('../models/Rent');

module.exports = {
    addGet: (req, res) => {
        res.render('car/add');
    },
    addPost: (req, res) => {
        const reqCar = req.body;
        reqCar.pricePerDay = Number(reqCar.pricePerDay);

        if (!reqCar.model || !reqCar.image || !reqCar.pricePerDay) {
            reqCar.error = 'Please fill all fields';
            res.render('car/add', reqCar);
            return;
        }

        Car.create(reqCar)
            .then(() => {
                res.redirect('/')
            })
            .catch(console.error);
    },
    allGet: (req, res) => {
        Car
            .find({isRented: false})
            .then((cars) => {
                res.render('car/all', {cars})
            })
            .catch(console.error);
    },
    rentGet: (req, res) => {
        const id = req.params.id;

        Car
            .findById(id)
            .then((car) => {
                res.render('car/rent', car)
            })
            .catch(console.error);
    },
    rentPost: async (req, res) => {
        const days = Number(req.body.days);
        const car = req.params.id;
        const owner = req.user._id;

        try {
            const rent = await Rent.create({ days, car, owner });
            const carObj = await Car.findById(car);
            carObj.isRented = true;
            await carObj.save();

            req.user.rents.push(rent._id);
            await req.user.save();

            res.redirect('/car/all');
        } catch (err) {
            console.error(err);
        }
    },
    editGet: (req, res) => {
        const id = req.params.id;

        Car
            .findById(id)
            .then((car) => {
                res.render('car/edit', car);
            })
            .catch(console.error);
    },
    editPost: (req, res) => {
        const id = req.params.id;
        const { model, image, pricePerDay} = req.body;

        Car
            .findById(id)
            .then((car) => {
                car.model = model;
                car.image = image;
                car.pricePerDay = pricePerDay;
                return car.save();
            })
            .then(() => {
                res.redirect('/car/all');
            })
            .catch(console.error);
        
        // Second approach
        // const updatedCar = { model, image, pricePerDay};
        // Car.findByIdAndUpdate(id, updatedCar)
        //     .then(() => {
        //         res.redirect('/car/all');
        //     })
        //     .catch(console.error);
    }
};