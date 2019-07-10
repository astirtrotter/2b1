import {combineReducers} from "redux";

import {authentication} from "./authentication.reducer";
import {registeration} from "./register.reducer";
import {admins} from "./admin.reducer";

const rootReducer = combineReducers({
  authentication,
  registeration,
  admins
});

export default rootReducer;
