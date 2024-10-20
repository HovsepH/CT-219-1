class Dictionary {
    #hashTable;

    constructor() {
        this.#hashTable = new HashTable();
    }

    addPair(key, value) {
        let pair = {
            key : key, 
            value : value
        };
        this.#hashTable.addPair(pair);
    }

    printContent() {
        this.#hashTable.printTable();
    }
}

class HashTable {
    #table = [];
    #filledBuckets;

    constructor() {
        this.#filledBuckets = 0;
        this.#table = new Array(16).fill(null);
    }

    addPair(pair) {
        let hashCode = generateHash(pair.key);
        let index = Math.abs(hashCode % this.#table.length);

        this.#addInBucket(index, pair);
        this.#resizeTableIfNeeded();
    }

    #addInBucket(index, pair) {
        var bucket = this.#table[index];

        if(!bucket){
            bucket = [];
            this.#table[index] = bucket;
            ++this.#filledBuckets;
        }
        else {
            let replaced = false;
            
            for (let i = 0; i < bucket.length; i++) {
                if (bucket[i].key === pair.key) {
                    bucket[i].value = pair.value;  
                    replaced = true;
                    break;
                }
            }
            
            if(!replaced) {
                bucket.push(pair);
            }
        }
    }

    #resizeTableIfNeeded() {
        const loadFactor = this.#filledBuckets / this.#table.length;

        if(loadFactor >= 0.75) {
            const oldTable = this.#table;
            this.#table = new Array(oldTable.length * 2).fill(null);
            this.#table.length = excistingTable.length * 2;
            this.#filledBuckets = 0;

            for(const bucket of oldTable){
                if(bucket){
                    for(pair of bucket){
                        this.addPair(pair);
                    }
                }
            }
        }
    }

    printTable(){
        for(let i = 0; i < this.#table.length; i++) {
           const bucket = this.#table[i];
           if(bucket){
                console.log(`Bucket ${i}: `)
                for(const pair of bucket){
                    console.log(`   ${pair.key} => ${pair.value}`);
                }
           }
        }
    }
}

function generateHash(str){
    let hash = 0;

    for(let i = 0; i < str.length; i++){
        let char = str.charCodeAt(i);
        hash = ((hash << 5) - hash) + char;
        hash = hash & hash;
    }

    return hash;
}


const dictionary = new Dictionary();
dictionary.addPair("car", "vehicle");
dictionary.addPair("honda", "another vehicle");
dictionary.addPair("car", "updated vehicle");
dictionary.printContent();