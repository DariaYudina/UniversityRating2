from __future__ import unicode_literals
import itertools
import sys
import numpy as np
import matplotlib
import matplotlib.pyplot as plt
import scipy
from scipy import integrate

# Как я понял p это стартовые значения по оси ординат


# остальные f = 1, мб загнать в массив, чтобы коэфы можно было из интерфейса менять, хотя вроде
# это в задание не входит, но мб удобнее формулы будет читать, аля f7[0], f7[1], f[2] - коэфы a,b,c (ax2+bx+c)
# f7 = [0.1, 0.5, 0.3],
# f14 = [0.5, 0.1, 0.3],
# f19 = [0.9, 0.2],
# f24 = [0.5, 0.1],
# f42 = [0.2,0.1,0.1]
def sum2(P): 
  sum = 0
  for i in range(1,11):
    sum += i*P[i] 
  return sum / 11


def model(P, t):
    # Нам поступает на вход ax2 + bx2 + c (3штуки)
    # И ax + b (2штуки)
    # a1, b1, c1 = f1
    # a2, b2, c2 = f2
    # a3, b3, c3 = f3
    # a4, b4 = f4
    # a5, b5 = f5 
    a1, b1, c1 = [0.1, 0.5, 0.3]
    a2, b2, c2 = [0.5, 0.1, 0.3]
    a3, b3, c3 = [0.2,0.1,0.1]
    a4, b4 = [0.9, 0.2]
    a5, b5 = [0.5, 0.1] 

    def E(t):
        z = -0.35
        # if t > 0.3 and t < 0.6:
        #     z = 0.55
        # elif t > 0.6:
        #     z = -0.85
        return z

    return [
        (0.9 * (P[0] * P[2] * P[3] * P[4] * P[5] * P[6] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) + #1
        (0.9 * (a1 * P[0]**2 + b1 * P[0] + c1) * P[3] * P[4] * P[6] * P[9] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) +  # 2
        (0.9 * (a2 * P[0]**2 + b2 * P[0] + c2) * P[4] * P[7] * P[9] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) +  # 3
        (0.9 * (a4 * P[0] + b4) + P[1] * P[2] * P[6] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) +  # 4
        (0.9 * (a5 * P[0] + b5) * P[1] * P[6] * P[7] * P[8] * P[9] * P[11] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) +  # 5
        (0.9 *  P[0] * P[1] * P[7] * P[9] * P[10] * P[0] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) +  # 6
        0.9 * (P[6] * P[9] * P[10] * P[11] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) +  # 7
        0.9 * (a3*P[6]**2 * b3*P[6] * P[6] + c3) * ((E(t) + E(t) + E(t))) - (P[9] * P[10] * P[11] * (E(t) + E(t))) + # 8
        0.9 * (P[3] * P[5] * P[6] * P[7] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) + # 9
        0.9 * (P[3] * P[5] * P[7] * (E(t) + E(t) + E(t)) - (E(t) + E(t))) + #10
        0.1 * (P[0] * P[3] * P[5] * P[7] * (E(t) + E(t) + E(t)) - P[8] * (E(t) + E(t)))) / 11, #11, # 0

        P[0] * P[2] * P[3] * P[4] * P[5] * P[6] * (E(t) + E(t) + E(t)) -  P[11] * (E(t) + E(t)), #1
        (a1 * P[0]**2 + b1 * P[0] + c1) * P[3] * P[4] * P[6] * P[9] * (E(t) + E(t) + E(t)) - P[5] * P[10] * (E(t) + E(t)),  # 2
        (a2 * P[0]**2 + b2 * P[0] + c2) * P[4] * P[7] * P[9] * (E(t) + E(t) + E(t)) - (E(t) + E(t)),  # 3
        (a4 * P[0] + b4) + P[1] * P[2] * P[6] * (E(t) + E(t) + E(t)) - P[11] * (E(t) + E(t)),  # 4
        (a5 * P[0] + b5) * P[1] * P[6] * P[7] * P[8] * P[9] * P[11] * (E(t) + E(t) + E(t)) - (E(t) + E(t)),  # 5
        P[0] * P[1] * P[7] * P[9] * P[10] * P[0] * (E(t) + E(t) + E(t)) - (E(t) + E(t)),  # 6
        P[6] * P[9] * P[10] * P[11] * (E(t) + E(t) + E(t)) - (E(t) + E(t)),  # 7
        (a3*P[6]**2 * b3*P[6] * P[6] + c3) * ((E(t) + E(t) + E(t))) - (P[9] * P[10] * P[11] * (E(t) + E(t))), # 8
        P[3] * P[5] * P[6] * P[7] * (E(t) + E(t) + E(t)) - (E(t) + E(t)), # 9
        P[3] * P[5] * P[7] * (E(t) + E(t) + E(t)) - (E(t) + E(t)), #10
        P[0] * P[3] * P[5] * P[7] * (E(t) + E(t) + E(t)) - P[8] * (E(t) + E(t)) #11
    ]

def sum1(R):
  n = []
  for i in R:
    n.appen(sum(i))
  return n

def solve(d, t):
    # p = [
    #     0.1,
    #     0.2,
    #     0.3,
    #     0.4,
    #     0.5,
    #     0.6,
    #     0.7,
    #     0.8,
    #     0.9,
    #     0.93,
    #     0.95,
    #     0.97,
    # ]
    p = [
        0.12,
        0.14,
        0.16,
        0.18,
        0.2,
        0.22,
        0.24,
        0.26,
        0.7,
        0.3,
        0.32,
        0.5,
    ]
    # p = [
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    #     0.5,
    # ]
    solution = scipy.integrate.odeint(d, p, t)
    res = list(map(list, zip(*solution)))
    return res


def plot_solution(P, t, ylim=(0, 0.51), figsize=(12, 6), dpi=500,
                  colors=matplotlib._color_data.TABLEAU_COLORS,
                  legend='upper right', output='sol.png'):
    linestyles = ['-', '--', '-.', ':']
    lw = 0.8

    plt.figure(1, figsize=figsize)
    plt.xlabel('t')
    plt.grid(True)

    plt.ylim(*ylim)

    state = [
        'Качество',
        'Корректность',
        'Надежность',
        'Эффективность',
        'Целостность',
        'Практичность',
        'Тестируемость',
        'Гибкость',
        'Сопровождаемость',
        'Многократное использование',
        'Функциональная совместимость',
        'Мобильность'
    ]

    for i, (p, (style, color)) in enumerate(zip(P, itertools.cycle(itertools.product(linestyles, colors)))):
        plt.plot(t, p, linewidth= (1.5 if i == 0 else lw), linestyle=style,
                 color=color, label=f'{state[i]}')

    # plt.plot(t, sum1(P), linewidth=1, linestyles='-', color='red', label='sum')

    if legend:
        # plt.legend(loc=legend)
        plt.legend( loc='upper left')

    plt.subplots_adjust(left=0.035, right=0.89, top=0.97, bottom=0.08)
    # plt.savefig(output, dpi=dpi)
    plt.xticks(np.arange(0, 1.01, step=0.1))
    plt.show()
    plt.gcf().clear()


# l = [10, 10]
# m = [5, 5]

yLim = (0, 1.5)
t = np.linspace(0, 1, num=50)
P = solve(model, t)
print(len(P))

plot_solution(P, t, yLim)
