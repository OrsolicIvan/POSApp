export interface User {
    id: number;
    userName: string;
    email: string;
    token: string;
    roles: string[];
}
export interface GetUser {
    id: number;
    userName: string;
    email: string;
    
}