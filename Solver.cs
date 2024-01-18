namespace Overround;
// inputs
//     init_estimate
//     init_step
//     error_threshold
//     max_iterations
//     loss_func

// let last_error = loss_func(overround(init_estimate))
// if last_error < error_threshold
//     return init_estimate
// end if

// let last_estimate = init_estimate
// let step = init_step
// let iteration = 1

// loop
//     let estimate = last_estimate + step
//     let error = loss_func(overround(estimate))
//     if error < error_threshold
//         return estimate
//     else if error ≥ last_error
//         step = –step / 2
//     end if

//     if iteration ≥ max_iterations
//         return estimate
//     end if
//     iteration = iteration + 1
//     last_estimate = estimate
//     last_error = error
// end loop

public class Solver
{
    
    public static double Solve(double initEstimate, double initStep, double errorThreshold, int maxIterations, Func<double, double> lossFunc)
    {
        double lastError = lossFunc(initEstimate);
        if (lastError < errorThreshold) 
        {
            return initEstimate;
        }

        double lastEstimate = initEstimate;
        double step = initStep;
        int iteration = 1;
        while (true) {
            double estimate = lastEstimate + step;
            double error = lossFunc(estimate);
            if (error < errorThreshold)
            {
                return estimate;
            }
            else if (error >= lastError)
            {
                step = -step / 2;
            }

            if (iteration++ > maxIterations)
            {
                return estimate;
            }
            lastEstimate = estimate;
            lastError = error;
        }
    }
}