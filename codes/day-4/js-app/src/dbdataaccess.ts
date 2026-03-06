import { DataAccess } from "./dataaccess";

export class DbDataAccess extends DataAccess{   
    constructor(path: string) {
        super(path)
    }
    override getData(): string {
       return "db data"
    }
}