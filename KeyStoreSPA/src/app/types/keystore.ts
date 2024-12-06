import { DateTime } from 'luxon';
import { User } from './user';

export interface KeyStore {
    id: number;
    keyName: string;
    keyValue: string;
    createdAt: DateTime;
    userId: number;
    user: User;
}