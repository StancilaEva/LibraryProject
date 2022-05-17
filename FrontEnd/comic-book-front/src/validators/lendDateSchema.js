import Joi from "joi";
export const lendDateSchema = Joi.object({
    startLendDate: Joi.date().required().messages({
        'any.required':`start date is mandatory`,
        'date.base':`Invalid date`,
        'date.greater':`Starting date cannot be in the past`
    }),
    endLendDate: Joi.date().required()
    .messages({
        'any.required':`start date is mandatory`,
        'date.base':`Invalid date`,
        'date.greater':`End date should be after the starting date`
    })
})
