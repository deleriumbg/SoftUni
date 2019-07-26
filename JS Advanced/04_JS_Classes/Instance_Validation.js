class CheckingAccount{
    constructor(clientId, email, firstName, lastName){
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.products = [];
    }

    get clientId(){
        return this._clientId;
    }

    set clientId(id){
        const regex = /^[0-9]{6}$/gm;
        if (!regex.test(id)) {
            throw new TypeError('Client ID must be a 6-digit number');
        }
        this._clientId = id;
    }

    get email(){
        return this._email;
    }

    set email(text){
        const regex = /^[\w]+@[a-zA-Z.]+$/gm;
        if (!regex.test(text)){
            throw new TypeError('Invalid e-mail');
        }
        this._email = text;
    }

    get firstName(){
        return this._firstName;
    }

    set firstName(text){
        if (text.length < 3 || text.length > 20) {
            throw new TypeError('First name must be between 3 and 20 characters long');
        }
        const regex = /^[A-Za-z]+$/gm;
        if (!regex.test(text)){
            throw new TypeError('First name must contain only Latin characters');
        }
        this._firstName = text;
    }

    get lastName(){
        return this._lastName;
    }

    set lastName(text){
        if (text.length < 3 || text.length > 20) {
            throw new TypeError('Last name must be between 3 and 20 characters long');
        }
        const regex = /^[A-Za-z]+$/gm;
        if (!regex.test(text)){
            throw new TypeError('Last name must contain only Latin characters');
        }
        this._lastName = text;
    }
}