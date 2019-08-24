import { useReducer as useReducer$$1 } from "/web_modules/react.js";
import * as react from "/web_modules/react.js";
import { declare, Union } from "./fable-library.2.3.19/Types";
import { union } from "./fable-library.2.3.19/Reflection";
import { Helpers$$$equalsButFunctions as Helpers$0024$0024$0024equalsButFunctions } from "./Fable.React.5.2.6/Fable.React.Helpers";
import { FunctionComponent$$$Of$$Z603636D8 as FunctionComponent$0024$0024$0024Of$0024$0024Z603636D8 } from "./Fable.React.5.2.6/Fable.React.FunctionComponent";
import * as react$002Ddom from "/web_modules/react-dom.js";
export const useReducer = useReducer$$1;
export const Msg = declare(function App_Msg(tag, name, ...fields) {
  Union.call(this, tag, name, ...fields);
}, Union);
export function Msg$reflection() {
  return union("App.Msg", [], Msg, () => ["Increase", "Decrease"]);
}
export const App = FunctionComponent$0024$0024$0024Of$0024$0024Z603636D8(function () {
  const init = 0;

  const update = function update(state, msg) {
    if (msg.tag === 1) {
      return state - 1 | 0;
    } else {
      return state + 1 | 0;
    }
  };

  const patternInput = useReducer(update, init);
  const state$$1 = patternInput[0] | 0;
  const dispatch = patternInput[1];
  return react.createElement("div", {}, ...[react.createElement("h1", {}, ...["Pika pika"]), react.createElement("div", {
    className: "card"
  }, ...[react.createElement("div", {
    className: "card-body"
  }, ...[react.createElement("h2", {
    className: "card-title"
  }, ...["Current state:"]), react.createElement("h2", {
    className: "text-center"
  }, ...[react.createElement("strong", {}, ...[state$$1])]), react.createElement("button", {
    className: "btn btn-primary mr-2",
    onClick: function (_arg1) {
      dispatch(new Msg(0, "Increase"));
    }
  }, ...["Increase"]), react.createElement("button", {
    className: "btn btn-secondary",
    onClick: function (_arg2) {
      dispatch(new Msg(1, "Decrease"));
    }
  }, ...["Decrease"])])])]);
}, "App", function (x, y) {
  return Helpers$0024$0024$0024equalsButFunctions(null, null);
});
react$002Ddom.render(App(), document.getElementById("app"));