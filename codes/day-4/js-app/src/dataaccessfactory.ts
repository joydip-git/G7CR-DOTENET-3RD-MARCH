import { DataAccess } from "./dataaccess";
import { DbDataAccess } from "./dbdataaccess";

export class DataAccessFactory{
    static createDataAccessObject(choice: number):DataAccess|null {
        let dataAccess: DataAccess|null;
        switch (choice) {
            case 1:
                dataAccess = new DbDataAccess("db path");
                break;
        
            default:
                dataAccess = null;
                break;
        }
        return dataAccess
    }
}