import {adminConstants} from "../_constants";

export function admin(state = {}, action) {
  switch (action.type) {
    case adminConstants.GET_INFO_REQUEST:
      return {loading: true};
    case adminConstants.GET_INFO_SUCCESS:
      return {admin: action.admin};
    default:
      return state;
  }
}
