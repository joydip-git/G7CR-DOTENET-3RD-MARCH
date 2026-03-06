import { DataAccess } from "./dataaccess";
import { DataAccessFactory } from "./dataaccessfactory";

const dataAccessObject: DataAccess | null = DataAccessFactory.createDataAccessObject(2);

const data = dataAccessObject?.getData()
console.log(data);