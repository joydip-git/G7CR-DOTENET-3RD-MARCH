export abstract class DataAccess{
    constructor(private path: string) {
        
    }
    abstract getData(): string;
}