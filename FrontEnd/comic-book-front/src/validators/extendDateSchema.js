import Joi from "joi";
export const extendDateSchema = Joi.object({
    endLendDate: Joi.date().greater("now").required()
    .messages({
        'any.required':`start date is mandatory`,
        'date.base':`Invalid date`,
        'date.greater':`Invalid End Date`
    })
})
