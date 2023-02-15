import { createReducer, on } from '@ngrx/store';
import { counterEvents } from '../actions/counter.actions';

export interface CounterState {
  current: number;
}

const initialState: CounterState = {
  current: 0,
};

export const reducer = createReducer(
  initialState,
  on(counterEvents.countIncremented, (s) => ({ ...s, current: s.current + 1 })),
  on(counterEvents.countDecremented, (s) => ({ ...s, current: s.current - 1 }))
);
