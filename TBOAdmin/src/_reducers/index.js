import {combineReducers} from "redux";

import {authentication} from "./authentication.reducer";
import {registeration} from "./register.reducer";

const rootReducer = combineReducers({
  authentication,
  registeration
});

export default rootReducer;
