import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { createReducer, Action, on } from '@ngrx/store';

export interface ItemEntity {
  id: string;
  description: string;
  type: ItemType;
  link: string;
}

export type ItemType = 'Book' | 'Video' | 'Blog' | 'Tutorial' | 'Other';
export interface ItemState extends EntityState<ItemEntity> {}

export const adapter = createEntityAdapter<ItemEntity>();

const initialState = adapter.getInitialState();

export const reducer = createReducer(initialState);
