import Joi from "joi";
const today = new Date()
const yesterday = new Date(new Date().setHours(23, 59, 59, 999))

yesterday.setDate(yesterday.getDate() - 1)
export const lendDateSchema = Joi.object({
    startLendDate: Joi.date().required().greater(yesterday).messages({
        'any.required':`start date is mandatory`,
        'date.base':`Invalid date`,
        'date.greater':`Starting date cannot be in the past`,
        'date.min':`Starting date cannot be in the past`
    }),
    endLendDate: Joi.date().greater("now").greater(Joi.ref("startLendDate")).required()
    .messages({
        'any.required':`start date is mandatory`,
        'date.base':`Invalid date`,
        'date.greater':`Invalid End Date`
    })
})
