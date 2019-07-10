import {combineReducers} from "redux";

import {auth} from "./auth.reducer";
import {registeration} from "./register.reducer";
import {admin} from "./admin.reducer";
import {alert} from './alert.reducer'

const rootReducer = combineReducers({
  auth,
  registeration,
  admin,
  alert
});

export default rootReducer;
