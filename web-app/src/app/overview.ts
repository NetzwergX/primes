
import { observable } from 'aurelia-framework';
export class Overview {

    @observable candidate : number = 0;
    message : string = "We'll automagically check!"
    valid : boolean = false;
    checked : boolean = false;

    @observable bias : number = 0;
    next : number = 2;
    message2 : string = "";

    count : number = 100;
    primes : number[] = [];
    message3 : string = "";

    fetchPrimes() : void {
        this.message3 = "Fetching...";
        fetch(`http://localhost:8080/api/prime/fetch?after=${this.primes[this.primes.length-1] ?? 0}&limit=${this.count}`)
            .then(response => response.json())
            .then(data =>  this.primes = this.primes.concat(data))
            .then(() => this.message3 = "Done");
    }

    biasChanged() : void {
        console.log("Bias changed ", this.bias);
        this.message2 = "Checking...";
        fetch(`http://localhost:8080/api/prime/next/${this.bias}`)
            .then(response => response.json())
            .then(data => this.next = data)
            .then(() => this.message2 = "Done");
    }

    candidateChanged() : void {
        console.log("Candidate changed ", this.candidate);
        this.message ="Checking...";
        this.valid = false;
        this.checked = false;

        fetch(`http://localhost:8080/api/prime/check/${this.candidate}`)
            .then(response => response.json())
            .then(data =>  this.valid = data)
            .then(() => this.checked = true)
            .then(() => this.message = this.valid ? "It's a prime!" : "This doesn't look right.");
    }
}
