import { createActionGroup, props } from '@ngrx/store';
import { ItemEntity } from '../reducers/items.reducer';

export const itemsEvents = createActionGroup({
  source: 'Items Evens',
  events: {},
});

export const itemsDocuments = createActionGroup({
  source: 'Items Documents',
  events: {
    items: props<{ payload: ItemEntity[] }>(),
  },
});
