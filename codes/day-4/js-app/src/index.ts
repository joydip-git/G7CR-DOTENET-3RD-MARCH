/*
import { DataAccess } from "./dataaccess";
import { DataAccessFactory } from "./dataaccessfactory";

const dataAccessObject: DataAccess | null = DataAccessFactory.createDataAccessObject(2);

const data = dataAccessObject?.getData()
console.log(data);

*/
const numbers = [1, 2, 3, 4]

function* getValues() {
    // const values = [];
    // for (let index = 0; index < numbers.length; index++) {
    //     const element = numbers[index];
    //     values.push(element)
    // }
    // return values;

    for (let index = 0; index < numbers.length; index++) {
        const element = numbers[index];
        yield element
    }
}

const generator = getValues()
setInterval(
    () => console.log(generator.next()),
    1000
)

